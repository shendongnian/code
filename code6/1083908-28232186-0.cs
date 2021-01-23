    public task ProcessValidFile(fileProcessDataModel model)
    {
        employeeWorkedDataservice service =new employeeWorkedDataservice()
 
        return Task.Factory.StartNew(() =>
        {
            service.ProcessEmployeeDataFile(model.DataSetToProcess, OriginalFileName, this, model.Source);
        },
        CancellationToken.None,
        TaskCreationOptions.DenyChildAttach,
        TaskScheduler.FromCurrentSynchronizationContext());    
    }
    [HttpPost]
    public ActionResult FileUpload(HttpPostedFileBase fileUpload)       
    {
        Coreservice objVDS = new Coreservice ();
       //validate the contents of the file 
       model =objVDS. ValidateFileContents(fileUpload);
       // if file is valid start processing asynchronously
       // This returns a task, but if we're not interested in waiting
       // for its results, we can ignore it.
       objVDS.ProcessValidFile(model);
       return view();
    }
