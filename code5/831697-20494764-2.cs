    DateTime alarmTime = new DateTime(2013,12,10,4,0,0);
    System.Windows.Forms.Timer alarmTimer = new System.Windows.Forms.Timer();
    alarmTimer.Interval = (alarmTime - DateTime.Now).Milliseconds;
    alarmTimer.Tick += alarmTimer_Tick;
    alarmTimer.Start();
