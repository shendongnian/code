    public void lookForWork()
    {     
       var custs = _IRepository.GetCustomers();
       var conf = _IRepository.GetConfig(); 
       foreach (var custRow in custs)
       { 
           var localCustRow = custRow;
           worker = new BackgroundWorker();
           worker.WorkerSupportsCancellation = true;
           worker.DoWork += (obj, e) => 
               checkWork(conf.Where(x => x.Code == localCustRow.Code).SingleOrDefault());
           worker.RunWorkerAsync();
       }
    }
