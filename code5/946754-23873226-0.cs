    ServiceController sc = new ServiceController(svr_name);
    if (sc.Status != ServiceControllerStatus.Stopped)
    {
        sc.Stop();
        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
    }
