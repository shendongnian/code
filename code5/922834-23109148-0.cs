      public void pinger(string host)
      {
      var bw = new BackgroundWorker();
      bw.DoWork += delegate(object sender, DoWorkEventArgs e)
      {
          var ping = new System.Net.NetworkInformation.Ping();
        
         try
        {
          var result =  ping.Send(host);
          e.Result = new object[] { result};
        }
        catch(Exception ex)
        {
          // Catch specific exceptions here as needed
        }
      };
      bw.RunWorkerCompleted += (bw_txt_results);
      bw.RunWorkerAsync();
     }
    private void bw_txt_results(object sender, RunWorkerCompletedEventArgs e)
     {
        txt_result = e.result[0].ToString();
     }
