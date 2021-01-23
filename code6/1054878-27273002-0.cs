    HIDNewDeviceEventMonitor ok;
    public ClassName()
    {
       ok = new HIDNewDeviceEventMonitor();
       ok.Inserted += someNewEvent;  // <-- my problem
    }
