    // get all the data you need separately
    Candidate candidate = null; // no idea of the real type
    Thread t1 = new Thread(() => candidate = AddCandidate2Daxtra(request, args));
    t1.Start();
    HRXML HRXML = null; // no idea of the real type
    Thread t2 = new Thread(() => HRXML = parsecv(profile));
    t2.Start();
    Attachment att = null; // no idea of the real type
    Thread t3 = new Thread(() => att = Print2Flash(alias, bytes, args));
    t3.Start();
    while (t1.IsAlive || t2.IsAlive || t3.IsAlive)
    {
        Thread.Sleep(1000);
    }
