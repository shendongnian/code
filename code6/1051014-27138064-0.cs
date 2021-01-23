    foreach (var c in grid.Columns)
            {
                var column = c as Xceed.Wpf.DataGrid.Column;
                column.DisplayMemberBinding = new System.Windows.Data.Binding("[" + column.FieldName + "]");
            } 
