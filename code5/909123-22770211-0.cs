        //Time trigger
        IBackgroundTrigger everyMinuteTrigger = new TimeTrigger(15, false);
        btb.SetTrigger(everyMinuteTrigger);
        //one of the standart tirgger
        btb.SetTrigger(new SystemTrigger(SystemTriggerType.InternetAvailable, false));
