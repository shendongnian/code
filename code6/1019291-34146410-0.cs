    [Disable("DisableMyTimerJob")]
    public static void TimerJob([TimerTrigger("00:01:00")] TimerInfo timerInfo, TextWriter log)
    {
        log.WriteLine("Scheduled job fired!");
    }
