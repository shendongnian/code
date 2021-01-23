    task.ContinueWith(t =>
       {
          try
          {
              // this would re-throw an exception from task, if any
              var result = t.Result;
              // process result
              lbUsers.DataSource = JsonConvert.DeserializeObject<List<string>>(result);
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
              lbUsers.Clear();
              lbUsers.Items.Add("Error loading users!");
          }
       }, 
       CancellationToken.None, 
       TaskContinuationOptions.None, 
       TaskScheduler.FromCurrentSynchronizationContext()
    );
