      DateTime utcNow = DateTime.UtcNow;
      this.Refresh();
      while (this.Status != desiredStatus)
      {
        if (DateTime.UtcNow - utcNow > timeout)
          throw new System.ServiceProcess.TimeoutException(Res.GetString("Timeout"));
        Thread.Sleep(250);
        this.Refresh();
      }
