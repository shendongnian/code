    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Get application GUID
        string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
        WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
        // Get user SID
        string userSid = currentUser.User.ToString();
        // Construct application & user specific mutex ID
        string mutexID = string.Format(@"Global\{{{0}}}-{{{1}}}", appGuid, userSid);
        using (Mutex mutex = new Mutex(false, mutexID))
        {
            MutexAccessRule allowUserRule = new MutexAccessRule(currentUser.User, MutexRights.FullControl, AccessControlType.Allow);
            MutexSecurity securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowUserRule);
            mutex.SetAccessControl(securitySettings);
            bool hasHandle = false;
            try
            {
                try
                {
                    hasHandle = mutex.WaitOne(5000, false);
                }
                catch (AbandonedMutexException)
                {
                    // Log the fact the mutex was abandoned in another process, it will still get aquired
                    hasHandle = true;
                }
                if (hasHandle == false) return;
                // Start application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            finally
            {
                if (hasHandle) mutex.ReleaseMutex();
            }
        }
    }
