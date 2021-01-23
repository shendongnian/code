	>	System.dll!System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback callback, object state) Line 1370	C#
 		System.Net.Http.dll!System.Net.Http.HttpClientHandler.StartGettingRequestStream(System.Net.Http.HttpClientHandler.RequestState state) + 0x82 bytes	
 		System.Net.Http.dll!System.Net.Http.HttpClientHandler.PrepareAndStartContentUpload.AnonymousMethod__0(System.Threading.Tasks.Task task) + 0x92 bytes	
 		mscorlib.dll!System.Threading.Tasks.ContinuationTaskFromTask.InnerInvoke() Line 59 + 0xc bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.Execute() Line 2459 + 0xb bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ExecutionContextCallback(object obj) Line 2815 + 0x9 bytes	C#
 		mscorlib.dll!System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state, bool preserveSyncCtx) Line 581 + 0xd bytes	C#
 		mscorlib.dll!System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state, bool preserveSyncCtx) Line 530 + 0xd bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ExecuteWithThreadLocal(ref System.Threading.Tasks.Task currentTaskSlot) Line 2785	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ExecuteEntry(bool bPreventDoubleExecution) Line 2728	C#
 		mscorlib.dll!System.Threading.Tasks.ThreadPoolTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task task, bool taskWasPreviouslyQueued) Line 91 + 0xb bytes	C#
 		mscorlib.dll!System.Threading.Tasks.TaskScheduler.TryRunInline(System.Threading.Tasks.Task task, bool taskWasPreviouslyQueued) Line 221 + 0x12 bytes	C#
 		mscorlib.dll!System.Threading.Tasks.TaskContinuation.InlineIfPossibleOrElseQueue(System.Threading.Tasks.Task task, bool needsProtection) Line 259 + 0xe bytes	C#
 		mscorlib.dll!System.Threading.Tasks.StandardTaskContinuation.Run(System.Threading.Tasks.Task completedTask, bool bCanInlineContinuationTask) Line 334 + 0xc bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ContinueWithCore(System.Threading.Tasks.Task continuationTask, System.Threading.Tasks.TaskScheduler scheduler, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskContinuationOptions options) Line 4626 + 0x12 bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ContinueWith(System.Action<System.Threading.Tasks.Task> continuationAction, System.Threading.Tasks.TaskScheduler scheduler, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskContinuationOptions continuationOptions, ref System.Threading.StackCrawlMark stackMark) Line 3840	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ContinueWith(System.Action<System.Threading.Tasks.Task> continuationAction, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskContinuationOptions continuationOptions, System.Threading.Tasks.TaskScheduler scheduler) Line 3805 + 0x1b bytes	C#
 		System.Net.Http.dll!System.Net.Http.HttpUtilities.ContinueWithStandard(System.Threading.Tasks.Task task, System.Action<System.Threading.Tasks.Task> continuation) + 0x2c bytes	
 		System.Net.Http.dll!System.Net.Http.HttpClientHandler.PrepareAndStartContentUpload(System.Net.Http.HttpClientHandler.RequestState state) + 0x16b bytes	
 		System.Net.Http.dll!System.Net.Http.HttpClientHandler.StartRequest(object obj) + 0x5a bytes	
 		mscorlib.dll!System.Threading.Tasks.Task.InnerInvoke() Line 2835 + 0xd bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.Execute() Line 2459 + 0xb bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ExecutionContextCallback(object obj) Line 2815 + 0x9 bytes	C#
 		mscorlib.dll!System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state, bool preserveSyncCtx) Line 581 + 0xd bytes	C#
 		mscorlib.dll!System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state, bool preserveSyncCtx) Line 530 + 0xd bytes	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ExecuteWithThreadLocal(ref System.Threading.Tasks.Task currentTaskSlot) Line 2785	C#
 		mscorlib.dll!System.Threading.Tasks.Task.ExecuteEntry(bool bPreventDoubleExecution) Line 2728	C#
 		mscorlib.dll!System.Threading.Tasks.Task.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem() Line 2664 + 0x7 bytes	C#
 		mscorlib.dll!System.Threading.ThreadPoolWorkQueue.Dispatch() Line 829	C#
 		mscorlib.dll!System.Threading._ThreadPoolWaitCallback.PerformWaitCallback() Line 1170 + 0x5 bytes	C#
 		[Native to Managed Transition]	
