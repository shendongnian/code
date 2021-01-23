    Progress<int> p = new Progress<int>();
    p.ProgressChanged += p_ProgressChanged;
    static void p_ProgressChanged(object sender, int e)
    {
        Console.WriteLine("Progress :"+e);
    }
