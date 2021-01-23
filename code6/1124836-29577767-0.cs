    // The async method:
    
            private static void LogAsync(Exception exception, string ip, MethodBase method, object parameters) {
        Task.Factory.StartNew(delegate {
                // some stuff });
            }
