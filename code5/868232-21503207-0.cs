    var WorkerTypeFromDB = GetWorkerTypeByField("Code", Worker.WorkerType.Code).FirstOrDefault();
    if (WorkerTypeFromDB == null)
    {
        session.Save(Worker.WorkerType); // Save/Insert not existing
    }
    else
    {
        Worker.WorkerType = WorkerTypeFromDB // assign the existing to our object
    }
