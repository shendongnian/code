    public partial class GyrasoftMessagingService : ServiceBase
    {
      protected override void OnStart(string[] args)
      {
         ThreadStart start = new ThreadStart(FaxWorker); // FaxWorker is where the work gets done
         Thread faxWorkerThread = new Thread(start);
         // set flag to indicate worker thread is active
         serviceStarted = true;
         // start threads
         faxWorkerThread.Start();
      }
      protected override void OnStop()
      {
         serviceStarted = false;
         // wait for threads to stop
         faxWorkerThread.Join(60);
         try
         {
            string error = "";
            Messaging.SMS.SendSMSTextAsync("5555555555", "Messaging Service stopped on " + System.Net.Dns.GetHostName(), ref error);
         }
         catch
         {
            // yes eat exception if text failed
         }
      }
      private static void FaxWorker()
      {
         // loop, poll and do work
      }
      
    }
