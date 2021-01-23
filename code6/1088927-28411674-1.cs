    public static TimeZone CurrentTimeZone {
        get {
            if (currentTimeZone != null)
                return currentTimeZone;
    
            lock (InternalSyncObject) {
                if (TimeZone.currentTimeZone == null)
                    TimeZone.currentTimeZone = new CurrentSystemTimeZone();
    
                return TimeZone.currentTimeZone;
            }
        }
    }
 
