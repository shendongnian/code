    public void Workers_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Cancelled) { BGW.ThisWorkersResult = "Cancelled By User"; }
      else if (e.Error != null) { BGW.ThisWorkersResult = "Error Encountered: " + e.Error.Message; }
      else
      {
          BGW.ThisWorkersResult = "Task Completed Successfully";
          //BGW.WorkersReturnObject = e.Result;
    		//background worker can't touch UI components
    		ListView_LocalComputers.ItemsSource = e.Result as List<DiscoveredComputer>;
      }
    }
