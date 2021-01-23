    private void BindingSource1_AddingNew(object sender, AddingNewEventArgs e)
            {
      if(need_insert_from_Current)
                    {
                    BindingSource bs =(BindingSource)sender;
                    DataRowView cur = (DataRowView)bs.Current;
                    DataView dv=(DataView)bs.List;
                    DataRowView drv=dv.AddNew();
                    // Collect data from current rec (except from the 1st value (Id is Identity !)
                    for (int i = 1; i <= dv.Table.Columns.Count-1; i++)
                    {
                        drv.Row[i] = cur.Row[i];
                    }
                    bs.Position = bs.Count - 1;
                    e.NewObject = drv;
                    need_insert = true;
                    need_insert_from_Current=false;
                    }
            }
