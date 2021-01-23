    private class DtWrapper
    { 
        public DateTime CurrentTime {get; set; }
    }
    DtWrapper currentTime = new DtWrapper { CurrentTime = new DateTime(2000, 01, 01) } ;
    Task task0 = new Task(n => WriteToConsole(((DtWrapper)n).CurrentTime), currentTime);
    for (; ; )
    {
        currentTime.CurrentTime = DateTime.Now;
        if (true)
        {
            task0.Start();
        }
        if (task0.Status.Equals(TaskStatus.Running))
        {
            // Do Something
        }
    }
