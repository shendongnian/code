    pbLoad.BeginInvoke(new Action<int>(a =>
    {
        if (!stopExecution)
        {
            pbLoad.Value = a;
            Debug.WriteLine(a); //a to output window                                        
        }
    }), new object[] { i });
