        public void DynamicGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }
            var grid = sender as GridView;
            if (grid == null)
            {
                return;
            }
            for (var i = 0; i < grid.Columns.Count; i++)
            {
                var column = grid.Columns[i] as TemplateField;
                if (column == null)
                    continue;
                var cell = e.Row.Cells[i];
                var dropdown = new DropDownList();
                cell.Controls.Add(dropdown);
            }
        }
