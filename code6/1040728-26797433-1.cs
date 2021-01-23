    void EclipseInstanceClosed(object sender, EventArgs e)
    {
      while (true)
      {
         Process runningEclipseProcess = Process.GetProcessesByName("ExclipeProcessName").FirstOrDefault();
    
         if (runningEclipseProcess != null)
         {
            //Exclipe is not closed. Wait for 1 sec and check again.
            Thread.Sleep(1000);
         }
         else
         {
            //Exclipe is closed. Notify the user
            MessageBox.Show("Eclipse was closed!");
            break;
        }
      }     
    }
