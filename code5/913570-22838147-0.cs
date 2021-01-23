    using (BackendServiceReference.ServiceClient service = new ServiceClient())
    {
        PrimesTask = service.GetPrimesServiceMethodAsync(Min, Count);
        DateTime ended = DateTime.Now;
        TimeSpan serviceTime = ended - started;
        ViewBag.ServiceTime = serviceTime;
        Primes = await PrimesTask;
    }
    ViewBag.Primes = Primes;
