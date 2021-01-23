    protected void myItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView row = e.Item.DataItem as DataRowView;
        if (null == row)
            return;
        DataSet1.table1Row currentRow = row.Row as DataSet1.table1Row ;
        if (currentRow != null)
        {
            BulletedList bList = e.Item.FindControl("bulletedList") as BulletedList;
            bList.Items.Add("Foo");
        }
    }
