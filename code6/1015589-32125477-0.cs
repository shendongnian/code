    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Schedulers;
    using EnvDTE;
    using EnvDTE80;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	
    namespace Test {
        public static class Debugging {
            private static _DTE Dte;
            private static readonly object DteLock = new object();
            private static bool Initialized;
            public static void AttachCurrentDebuggerToProcess(int processId) {
				lock (DteLock) {
					using (var sta = new StaTaskScheduler(numberOfThreads: 1)) {
						Task.Factory.StartNew(() => {
							if (System.Threading.Thread.CurrentThread.GetApartmentState() != ApartmentState.STA) throw new NotSupportedException("Thread should be in STA appartment state.");
							// Register the IOleMessageFilter to handle any threading errors.
							MessageFilter.Register();
							if (!Initialized) {
								using (var currentProcess = System.Diagnostics.Process.GetCurrentProcess())
								using (var vsInstances = System.Diagnostics.Process.GetProcessesByName("devenv").AsDisposable()) {
									foreach (var p in vsInstances.Enumerable) {
										_DTE dte;
										if (TryGetVSInstance(p.Id, out dte)) {
											//Will return null if target process doesn't have the same elevated rights as current process.
											Utils.Retry(() => {
												var debugger = dte?.Debugger;
												if (debugger != null) {
													foreach (Process2 process in debugger.DebuggedProcesses) {
														if (process.ProcessID == currentProcess.Id) {
															Dte = dte;
															break;
														}
													}
												}
											}, nbRetries: int.MaxValue, msInterval: 1000, retryOnlyOnExceptionTypes: typeof(COMException).InArray());
											if (Dte != null) break;
										}
									}
								}
								Initialized = true;
							}
							if (Dte != null) {
								foreach (Process2 process in Dte.Debugger.LocalProcesses) {
									if (process.ProcessID == processId) {
										process.Attach2();
										Dte.Debugger.CurrentProcess = process;
									}
								}
							}
							//turn off the IOleMessageFilter.
							MessageFilter.Revoke();
						}, CancellationToken.None, TaskCreationOptions.None, sta).Wait();
					}
				}
            }
            private static bool TryGetVSInstance(int processId, out _DTE instance) {
                IntPtr numFetched = IntPtr.Zero;
                IRunningObjectTable runningObjectTable;
                IEnumMoniker monikerEnumerator;
                IMoniker[] monikers = new IMoniker[1];
                GetRunningObjectTable(0, out runningObjectTable);
                runningObjectTable.EnumRunning(out monikerEnumerator);
                monikerEnumerator.Reset();
                while (monikerEnumerator.Next(1, monikers, numFetched) == 0) {
                    IBindCtx ctx;
                    CreateBindCtx(0, out ctx);
                    string runningObjectName;
                    monikers[0].GetDisplayName(ctx, null, out runningObjectName);
                    object runningObjectVal;
                    runningObjectTable.GetObject(monikers[0], out runningObjectVal);
                    if (runningObjectVal is _DTE && runningObjectName.StartsWith("!VisualStudio")) {
                        int currentProcessId = int.Parse(runningObjectName.Split(':')[1]);
                        if (currentProcessId == processId) {
                            instance = (_DTE)runningObjectVal;
                            return true;
                        }
                    }
                }
                instance = null;
                return false;
            }
            [DllImport("ole32.dll")]
            private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);
            [DllImport("ole32.dll")]
            private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
        }
    }
	namespace System.Threading.Tasks.Schedulers {
		/// <summary>Provides a scheduler that uses STA threads. From ParallelExtensionsExtras https://code.msdn.microsoft.com/Samples-for-Parallel-b4b76364/sourcecode?fileId=44488&pathId=574018573</summary> 
		public sealed class StaTaskScheduler : TaskScheduler, IDisposable {
			/// <summary>Stores the queued tasks to be executed by our pool of STA threads.</summary> 
			private BlockingCollection<Task> _tasks;
			/// <summary>The STA threads used by the scheduler.</summary> 
			private readonly List<Thread> _threads;
			/// <summary>Initializes a new instance of the StaTaskScheduler class with the specified concurrency level.</summary> 
			/// <param name="numberOfThreads">The number of threads that should be created and used by this scheduler.</param> 
			public StaTaskScheduler(int numberOfThreads) {
				// Validate arguments 
				if (numberOfThreads < 1) throw new ArgumentOutOfRangeException(nameof(numberOfThreads));
				// Initialize the tasks collection 
				_tasks = new BlockingCollection<Task>();
				// Create the threads to be used by this scheduler 
				_threads = Enumerable.Range(0, numberOfThreads).Select(i =>
				{
					var thread = new Thread(() => {
						// Continually get the next task and try to execute it. 
						// This will continue until the scheduler is disposed and no more tasks remain. 
						foreach (var t in _tasks.GetConsumingEnumerable()) {
							TryExecuteTask(t);
						}
					}) { IsBackground = true };
					thread.SetApartmentState(ApartmentState.STA);
					return thread;
				}).ToList();
				// Start all of the threads 
				_threads.ForEach(t => t.Start());
			}
			/// <summary>Queues a Task to be executed by this scheduler.</summary> 
			/// <param name="task">The task to be executed.</param> 
			protected override void QueueTask(Task task) {
				// Push it into the blocking collection of tasks 
				_tasks.Add(task);
			}
			/// <summary>Provides a list of the scheduled tasks for the debugger to consume.</summary> 
			/// <returns>An enumerable of all tasks currently scheduled.</returns> 
			protected override IEnumerable<Task> GetScheduledTasks() {
				// Serialize the contents of the blocking collection of tasks for the debugger 
				return _tasks.ToArray();
			}
			/// <summary>Determines whether a Task may be inlined.</summary> 
			/// <param name="task">The task to be executed.</param> 
			/// <param name="taskWasPreviouslyQueued">Whether the task was previously queued.</param> 
			/// <returns>true if the task was successfully inlined; otherwise, false.</returns> 
			protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) {
				// Try to inline if the current thread is STA 
				return
					Thread.CurrentThread.GetApartmentState() == ApartmentState.STA &&
					TryExecuteTask(task);
			}
			/// <summary>Gets the maximum concurrency level supported by this scheduler.</summary> 
			public override int MaximumConcurrencyLevel => this._threads.Count;
			/// <summary> 
			/// Cleans up the scheduler by indicating that no more tasks will be queued. 
			/// This method blocks until all threads successfully shutdown. 
			/// </summary> 
			public void Dispose() {
				if (_tasks != null) {
					// Indicate that no new tasks will be coming in 
					_tasks.CompleteAdding();
					// Wait for all threads to finish processing tasks 
					foreach (var thread in _threads) thread.Join();
					// Cleanup 
					_tasks.Dispose();
					_tasks = null;
				}
			}
		}
	}
