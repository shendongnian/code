    Task<string>.Factory.StartNew(() =>
    {
        // Your logic here
    }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
    .ContinueWith((p) =>
    {
         // This will be UI thread
         // p is the parent task
          progressBar1.Visible = false;
          
         // if parent task has faulted
         if (p.IsFaulted)
         {
              // Do with p.Exception field what ever you want - log it, show it.
              // for .net 4.0 you must read this property in order to prevent
              // application failure
               
              MessageBox.Show(p.Exception.Message);
              return;
         }
         // Here you know all about the parent task, so you can do the logic you want:
         MessageBox.Show(p.Result);
         
    }, TaskScheduler.FromCurrentSynchronizationContext());
