        if (Session["dataColumns"] == null)
        { 
           foreach (DataColumn dc in table.Columns)
           {
                if (dc.DataType != typeof(System.Boolean))
                { 
                    BoundField boundfield = new BoundField();
                    boundfield.DataField = dc.ColumnName;
                    boundfield.HeaderText = dc.ColumnName;
                    boundfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grid_view_habitaciones.Columns.Add(boundfield);
                 } else
                 {
                     CheckBoxField checkbox = new CheckBoxField();
                     checkbox.DataField = dc.ColumnName;
                     checkbox.HeaderText = dc.ColumnName;
                     checkbox.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                     grid_view_habitaciones.Columns.Add(checkbox);
                 }
            }
            Session["dataColumns"] = table.Columns;
        }
