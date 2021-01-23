      else if (n == SQLiteErrorCode.Locked || n == SQLiteErrorCode.Busy) // Locked -- delay a small amount before retrying
      {
        // Keep trying
        if (rnd == null) // First time we've encountered the lock
          rnd = new Random();
        // If we've exceeded the command's timeout, give up and throw an error
        if ((uint)Environment.TickCount - starttick > timeoutMS)
        {
          throw new SQLiteException(n, GetLastError());
        }
        else
        {
          // Otherwise sleep for a random amount of time up to 150ms
          System.Threading.Thread.Sleep(rnd.Next(1, 150));
        }
      }
