            DataTable dt = new DataTable();
            DataColumn column;
            DataRow row;
            DataView view;
            row = new DataRow();
            dt.Rows.Add(row);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "item";
            dt.Columns.Add(column);
   
            for (int i = 0; i < 10; i++)
            {
                row = dt.NewRow();
                row["id"] = i;
                row["item"] = "item " + i.ToString();
                dt.Rows.Add(row);
            }
            view = new DataView(dt);
            dataView1.ItemsSource = view;
