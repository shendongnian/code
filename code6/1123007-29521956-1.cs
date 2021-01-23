    #define USE_READERWRITER
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace TestProject
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                SenderDispatch dispatch = new SenderDispatch();
    
                List<Worker> workers = new List<Worker>();
    
                workers.Add( new Worker( dispatch, "A" ) );
                workers.Add( new Worker( dispatch, "B" ) );
                workers.Add( new Worker( dispatch, "C" ) );
                workers.Add( new Worker( dispatch, "D" ) );
    
                Thread.CurrentThread.Name = "Main thread";
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
    
                Stopwatch watch = new Stopwatch();
                
                watch.Start();
                workers.ForEach( x => x.Start() );
    
                for( int i = 0; i < 20; i++ )
                {
                    Thread.Sleep( 10000 );
                    dispatch.NewSender();
                }
    
                Console.WriteLine( "Stopping..." );
    
                workers.ForEach( x => x.Stop() );
                watch.Stop();
    
                Console.WriteLine( "Stopped" );
    
                long sum = workers.Sum( x => x.FinalCount );
    
                string message = 
                    "Sum of worker iterations: " + sum.ToString( "n0" ) + "\r\n" +
                    "Total time:               " + ( watch.ElapsedMilliseconds / 1000.0 ).ToString( "0.000" ) + "\r\n" +
                    "Iterations/ms:            " + sum / watch.ElapsedMilliseconds;
    
                MessageBox.Show( message );
            }
        }
    
        public class Worker
        {
            private SenderDispatch dispatcher;
            private Thread thread;
            private bool working;
    
            private string workerName;
    
            public Worker( SenderDispatch dispatcher, string workerName )
            {
                this.dispatcher = dispatcher;
                this.workerName = workerName;
    
                this.working = false;
            }
    
            public long FinalCount { get; private set; }
    
            public void Start()
            {
                this.thread = new Thread( Run );
                this.thread.Name = "Worker " + this.workerName;
    
                this.working = true;
                this.thread.Start();
            }
    
            private void Run()
            {
                long state = 0;
    
                while( this.working )
                {
                    this.dispatcher.DoOperation( workerName, state );
                    state++;
                }
    
                this.FinalCount = state;
            }
    
            public void Stop()
            {
                this.working = false;
    
                this.thread.Join();
            }
        }
    
        public class SenderDispatch
        {
            private Sender sender;
    
            private ReaderWriterLockSlim senderLock;
            
            public SenderDispatch()
            {
                this.sender = new Sender();
                this.senderLock = new ReaderWriterLockSlim( LockRecursionPolicy.NoRecursion );
            }
    
            public void DoOperation( string workerName, long value )
            {
    
    #if USE_READERWRITER
                this.senderLock.EnterReadLock();
                try
                {
                    this.sender.DoOperation( workerName, value );
                }
                finally
                {
                    this.senderLock.ExitReadLock();
                }
    #else 
                bool done = false;
    
                do
                {
                    try
                    {
                        this.sender.DoOperation( workerName, value );
                        done = true;
                    }
                    catch (ObjectDisposedException) { }
                }
                while( !done );
    #endif
    
            }
    
            public void NewSender()
            {
                Sender prevSender;
                Sender newSender;
    
                newSender = new Sender();
    
    #if USE_READERWRITER
                this.senderLock.EnterWriteLock();
                try
                {
                    prevSender = Interlocked.Exchange( ref this.sender, newSender );
                }
                finally
                {
                    this.senderLock.ExitWriteLock();
                }
    #else
                prevSender = Interlocked.Exchange( ref this.sender, newSender );
                prevSender.Dispose();
    
    #endif
                prevSender.Dispose();
    
            }
        }
    
        public class Sender : IDisposable
        {
            private bool disposed;
    
            public Sender()
            {
                this.disposed = false;
            }
    
            public void DoOperation( string workerName, long value )
            {
                if( this.disposed )
                {
                    throw new ObjectDisposedException( 
                        "Sender",
                        string.Format( "Worker {0} tried to queue work item {1}", workerName, value ) 
                    );
                }
    
                Thread.SpinWait( 100 );
            }
    
            public void Dispose()
            {
                this.disposed = true;
            }
        }
    }
