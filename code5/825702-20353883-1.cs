    // lock analog
        AutoRenewLease.DoConsequence("testBlob2", () =>
                                {
    // Some task
                                    if (collection == 0)
                                    {
                                        Thread.Sleep(1000 * 2);
                                        collection++;
                                    }
                                    Trace.WriteLine(tNo + " =====Collection=" + collection);
                                    Trace.WriteLine(tNo + " =====MustBe = 1");
                                });
