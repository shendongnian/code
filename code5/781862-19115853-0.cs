        Thread t1 = new Thread(() => response.Candidate = AddCandidate2Daxtra(request, args));
        t1.Start();
        t1.Join();
        Thread t2 = new Thread(() => response.Candidate.HRXML = parsecv(profile));
        t2.Start();
        Thread t3 = new Thread(() => response.Candidate.Attachments.Add(Print2Flash(alias, bytes, args)));
        t3.Start();
        while (/*t1.IsAlive == true || */t2.IsAlive == true || t3.IsAlive == true)
        {
            Thread.Sleep(1000);
        }
