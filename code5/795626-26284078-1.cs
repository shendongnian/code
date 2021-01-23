        private void mygrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
             GridView g = sender as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int index = e.Row.DataItemIndex - (g.PageIndex*g.PageSize);
                DataKey dataKey = g.DataKeys[index];
                string id = dataKey.Value.ToString();
                //if you just need the primary key, id will suffice, use the values collection for multiple keys
                //if you need values other than the primary key, use the code below
                var dataView = g.DataSource as DataView;
                if (dataView != null)
                {
                    DataRow dataRow = dataView[e.Row.DataItemIndex].Row;
                    object[] items = dataRow.ItemArray;
                    DataColumnCollection columns = dataRow.Table.Columns;
                   var myval =  items[columns.IndexOf("MyColumnsName")];
                   //store the index in a static variable if processing a huge number of rows
                }
            }
        }
