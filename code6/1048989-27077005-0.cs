    protected void drpEmployeeItemID_DataBound(object sender, RadComboBoxItemEventArgs e)
    {
       e.Item.Text = ((DataRowView)e.Item.DataItem)["ItemName"].ToString() ;
       e.Item.Value = ((DataRowView)e.Item.DataItem)["LotNo"].ToString(); 
    }
