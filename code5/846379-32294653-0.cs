    using (testentities te = new testentities())
    {
        //-------------------------------------------------------------
        // Simple stored proc
        //-------------------------------------------------------------
        var parms1 = new testone() { inparm = "abcd" };
        var results1 = te.CallStoredProc<testone>(te.testoneproc, parms1);
        var r1 = results1.ToList<TestOneResultSet>();
    }
