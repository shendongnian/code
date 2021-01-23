    public static class SessionManager
    {
     public static volatile List<int> activeSessionsPCIDs;
     public static volatile List<int> sessionsThatChangedStatus;
     public static volatile List<SessionObject> allSessions;
   
     static SessionManager()
     {
       Initialize();
     }
    public static void Initialize() {
        var t = Task.Factory.StartNew(() => {
           while(true)
           {
             SetProperties();
             Task.Delay(5);
           }
         });
    }
    public static void SetProperties() {
        SessionDataAccess sd = new SessionDataAccess();
        while (true) {
            allSessions = sd.GetAllSessions();
            activeSessionsPCIDs = new List<int>();
            sessionsThatChangedStatus = new List<int>();
            foreach (SessionObject session in allSessions) {
                if (session.status == 1) { //if session is active
                    activeSessionsPCIDs.Add(session.pcid);
                }
                if (session.status != session.prevStat) { //if current status doesn't match the previous status
                    sessionsThatChangedStatus.Add(session.pcid);
                }
            }
            Thread.Sleep(5000);
        }
    }
