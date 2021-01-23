        private void mygrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
             GridView g = sender as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int index = e.Row.DataItemIndex - (g.PageIndex*g.PageSize);
                DataKey dataKey = g.DataKeys[index];
                string id = dataKey.Value.ToString();
              
                var dataView = g.DataSource as DataView;
                if (dataView != null)
                {
                    DataRow dataRow = dataView[e.Row.DataItemIndex].Row;
                    object[] items = dataRow.ItemArray;
                    DataColumnCollection columns = dataRow.Table.Columns;
                   var myval =  items[columns.IndexOf("MyColumnsName")];
                }
            }
        }
