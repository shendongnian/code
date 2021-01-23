    private void simpleButton1_Click(object sender, EventArgs e)
    {        
        ShowLoadingPanel(listBox);    
        bw.RunWorkerAsync();       
    }
    void bw_DoWork(object sender,DoWorkEventArgs e)
    {           
        GetData();
    }
    private void GetData()
    {
        for (int i = 0; i < 500000; i++)
        {
            datatable.Rows.Add(new object[] { "raj", "raj", "raj", i });
        }
    }
    void ShowLoadingPanel(Control control)
    {
       //Doing some work here
    }
