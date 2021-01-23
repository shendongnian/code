        ....
        else
        {
              Console.WriteLine(string.Format("Total number of files transferred: {0}. Transfer Completed", TransferCount + 1));
              (sender as DispatcherTimer).Stop();
              (sender as DispatcherTimer).Tick -= dt_Tick;
              TransferCount = 0;
        }
