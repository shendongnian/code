    ...
    
    if (DateTime.Now.Hour == intAlarmHour && DateTime.Now.Minute == intAlarmMinute)
    {
        
    
        if (radTG.Checked == true)
        {
            Thread radTG = new Thread(radTGChecked);
            radTG.Start();
        }
        ...
    }
    
    ...
    
    public void radTGChecked() {
        SoundPlayer sound = new SoundPlayer(Properties.Resources.Celldweller);
        sound.PlaySync();
    }
