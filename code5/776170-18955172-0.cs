    try
    {
    ServiceController service = new ServiceController(service_name, computer_name);
    if (service.Status != ServiceControllerStatus.Running)
    {
    return false;
    }
    else
    {
    service.Stop();
    Thread.Sleep(60000);
    service.Start();
    }
    }
    catch (Exception exc)
    {
    return false;
    }
