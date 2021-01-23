    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    
    namespace MyService.Service
    {
        public class ASServiceBase : ServiceBase
        {
            #region Private Member
            private Thread myServiceThread;
            private bool myDoStop;
            #endregion
    
            #region Constructor
            /// <summary>
            /// Constructor
            /// </summary>
            public ASServiceBase()
            {
                myDoStop = false;
            }
            #endregion
    
            #region Public Methods
            #region OnStart
            protected override void OnStart(string[] args)
            {
                Start();
            }
    
            /// <summary>
            /// Start
            /// </summary>
            public void Start()
            {
                myServiceThread = new Thread(new ThreadStart(Do));
                myServiceThread.Start();
    
                MainThread = myServiceThread;
            }
            #endregion
    
            #region Do Anything
            /// <summary>
            /// Execute
            /// </summary>
            public void Do()
            {
                while (!myDoStop)
                {
                    // Do some stuff
                    Thread.Sleep(10);
                }
    
                LoggingManager.Singleton.Deactivate();
    
                // =====================================================================================
                // Stop anything
    
                // =====================================================================================
            }
            #endregion
    
            #region OnStop
            protected override void OnStop()
            {
                Stop();
            }
    
            /// <summary>
            /// Stop
            /// </summary>
            public void Stop()
            {
                myDoStop = true;
            }
            #endregion
    
            #endregion
    
            #region Private Methods
            
            #endregion
    
            #region Public Member
            /// <summary>
            /// Main Thread
            /// </summary>
            public static Thread MainThread
            {
                get;
                set;
            }
            #endregion
        }
    }
