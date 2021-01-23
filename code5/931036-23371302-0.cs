    public string GetAgentTime(double sec) {
      TimeSpan t = TimeSpan.FromSeconds(sec);
      return string.Format(
        "{0:D2}h:{1:D2}m:{2:D2}s",
        Math.Floor(t.TotalHours),
        t.Minutes,
        t.Seconds
      ); 
    }
