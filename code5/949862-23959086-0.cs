    void dostuff()
    {
        if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage_ProdOrders"])
        {
            dbTimer.Start();
        }
        else dbTimer.Stop();
      
    }
