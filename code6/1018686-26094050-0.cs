    var reset = new AutoResetEvent(false); // ComputeSalary should have access to reset
    .....
    ....
    
    if (flag)
    {
        foreach (string empNo in empList)
        {
             Thread thrd = new Thread(()=>ComputeSalary(empNo));
             threadList.Add(thrd);
             thrd.Start();
        }
        reset.WaitOne();
    }
    
    .....
    .....
    
    void ComputeSalary(int empNo)
    {
        .....
        reset.set()
    }
