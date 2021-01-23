    var WorkerFromDB = GetWorkerByField("Code", Worker.Code).FirstOrDefault();
    if (WorkerFromDB == null)
    {
        session.Save(Worker); // insert not existing
    }
    else
    {
        // here, we should assign the existing Worker ID to passed one
        Worker.ID = WorkerFromDB.ID; // current worker has same identifier
        session.Merge(Worker);       // both will be merged, latest changes will be applied      
    }
