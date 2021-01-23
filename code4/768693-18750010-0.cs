    //Get active entries from table, call getWorkList
    public static void WorkList(//Not sure of what path to use)
    {   
    //get active entries
    List<LogData> workList = GetWorkList();
    foreach(var work in workList)
    {
        if(File.Exists(work.fileLocation))
        {
            File.Delete(work.fileLocation);
        }
    }
    //check to see if date created in directory is older that x number of days
    if(DateTime.Now.Subtract(dt).TotalDays <= 1)
    {
        log.Info("This directory is less than a day old");
    }
    //if file is older than x number of days
    else if (DateTime.Now.Subtract(dt).TotalDays <= //not sure of what variable or property to use)
    {
        File.Delete
    }
    //delete file
}
