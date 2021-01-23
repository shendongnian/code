    PerformanceCounter PC = new PerformanceCounter();
    PC.CategoryName = "ServerProcess";
    PC.CounterName = "Working Set - Private";
    PC.InstanceName = JSP[0].ProcessName; //Process
    RAM_memorysize = PC.NextValue();            //float RAM_memorysize;
    PC.Close();
    PC.Dispose();
