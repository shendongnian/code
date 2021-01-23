    if (ids != null)
    {
        foreach (var id in ids)
        {
        string postIdVal = AddPublicationOnMonster(id);
        string url = string.Format("http://jobview.monster.com/getjob.aspx?JobID={0}",             postIdVal);
        System.Diagnostics.Process.Start(url); ;
        }   
    }
    else
    {
        DoSomething();
    }
