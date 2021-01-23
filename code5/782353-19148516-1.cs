    else
    {
       // step 1
       PassaggioIE bo = new PassaggioIE(...);
       WpassIE.RunWorkerAsync(bo);
       
       // wait for WpassIE to complete
       while(WpassIE.IsBusy) Application.DoEvents();
    
       if (condition#2) {
          // step 2
          ConfigurazioneSA csa = new ConfigurazioneSA(...);
          WconfiguraSA.RunWorkerAsync(csa);
       }
    }
