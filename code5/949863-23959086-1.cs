    void dostuff()
    {
        if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage_ProdOrders"])
        {
            dbTimer.Interval = 10000; // your interval in ms
            dbTimer.Start();
        }
        else dbTimer.Stop();
      
    }
