    private void btnDisplayFilter_Click(object sender, EventArgs e)
    {
        using(filterForm filter = new filterForm())
        {
             if(filter.ShowDialog(this) == DialogResult.OK)
             {
                 displayGridViewControl dg = new displayGridViewControl();
                 dg.myDatagridView.DataSource = filter.returnedDataList;
                 displayGridView.ShowDialog();
             }
         }
    }
