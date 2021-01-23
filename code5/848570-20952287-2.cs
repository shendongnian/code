    private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        MyReportData rpt = ComboBox1.SelectedItem as MyReportData;
        if(rpt != null)
        {
            ...
        }
    }
