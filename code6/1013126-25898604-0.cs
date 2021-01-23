    using(var Mutexhelper=new GlobalMutexHelper("reasonably unique Name"))
    {
    
     //Code any goes here
    }
     internal class GlobalMutexHelper : IDisposable
            {
            #region Constants and Fields
    
            /// <summary>
            /// The access rule.
            /// </summary>
            private readonly MutexAccessRule accessRule =
                new MutexAccessRule(
                    new SecurityIdentifier(WellKnownSidType.WorldSid, null), 
                    MutexRights.FullControl, 
                    AccessControlType.Allow);
    
            /// <summary>
            /// The obj.
            /// </summary>
            private readonly Mutex obj;
    
            /// <summary>
            /// The sec settings.
            /// </summary>
            private readonly MutexSecurity secSettings = new MutexSecurity();
    
            #endregion
    
            #region Constructors and Destructors
    
            /// <summary>
            /// Initializes a new instance of the <see cref="GlobalMutexHelper"/> class.
            /// </summary>
            /// <param name="mutexname">
            /// The mutexname.
            /// </param>
            /// <exception cref="TimeoutException">
            /// </exception>
            /// <exception cref="Exception">
            /// </exception>
            public GlobalMutexHelper(string mutexname)
            {
                if (mutexname.Trim() != string.Empty)
                {
                    this.secSettings.AddAccessRule(this.accessRule);
                    bool isNew;
                    this.obj = new Mutex(true, "Global\\SomeUniqueName_" + mutexname, out isNew);
                    this.obj.SetAccessControl(this.secSettings);
                    if (!isNew)
                    {
                        if (this.obj.WaitOne())
                        {
                            Console.WriteLine("Signalled");
                        }
                        else
                        {
                            throw new TimeoutException("Timedout while waiting for Mutex");
                        }
                    }
                }
                else
                {
                    throw new Exception("The mutex name cannot be empty");
                }
            }
    
            #endregion
    
    
            #region Public Methods and Operators
    
            /// <summary>
            /// The dispose.
            /// </summary>
            public void Dispose()
            {
                this.obj.ReleaseMutex();
                this.obj.Dispose();
            }
    
            #endregion
        }
