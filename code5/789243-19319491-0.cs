      var tokenSource2 = new CancellationTokenSource();
 
      foreach (MobileAccounts MobileAccount in ReceiverAccounts)
      {
        var rec = new Receiver();
        var ct = tokenSource2.Token;
        Task.Factory.StartNew(() => this.DoWorkEventArgs(rec, ct));
      }
     // Anywhere outside you can call tokenSource2.Cancel();
     private void DoWorkEventArgs(Receiver rec, CancellationToken ct)
     {
       // Were we already canceled?
       ct.ThrowIfCancellationRequested();
       bool moreToDo = true;
       while (moreToDo)
       {
           // Poll on this property if you have to do 
           // other cleanup before throwing. 
           if (ct.IsCancellationRequested)
           {
             // Clean up here, then...
             ct.ThrowIfCancellationRequested();
           }
        }
     }
