    if (DateTime.Now.Hour == intAlarmHour && DateTime.Now.Minute == intAlarmMinute)
    {
         System.Media.SoundPlayer sound = new System.Media.SoundPlayer(//unknown format);
         sound.PlaySync();
    }
