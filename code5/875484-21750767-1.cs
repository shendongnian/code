    protected void btnOK_Click(object sender, EventArgs e)
    {
        int number = int.Parse(txtNumber.Text == "" ? "0" : txtNumber.Text);
        for (int i = 0; i < number; i++)
        {
            //Create new DataList with copying ItemTemplate from dtlTemplate
            DataList dtl = new DataList();
            dtl.ID = "dtl" + i;
            dtl.ItemTemplate = dtlTemplate.ItemTemplate;
            
            //Add new DataList to form1 (parent control)
            form1.Controls.Add(dtl);
            
            //Set the same data source with dtlTemplate to new DataList
            dtl.DataSourceID = dtlTemplate.DataSourceID;
            dtl.DataBind();
        }
    }
