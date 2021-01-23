    using (PerformanceCounter pfc = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
    {
        MessageBox.Show(pfc.NextValue().ToString());
        Thread.Sleep(1000);
        MessageBox.Show(pfc.NextValue().ToString());
        Thread.Sleep(1000);
        MessageBox.Show(pfc.NextValue().ToString());
    }
