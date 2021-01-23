           private void dataGridView_Types_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (view.Columns[e.ColumnIndex].Name == "TypeTable_Color")
            {
                ColorDialog dlg = new ColorDialog();
                DialogResult res = dlg.ShowDialog();
                if (res == DialogResult.OK)
                {
                    DataGridViewCell cell = view[e.ColumnIndex, e.RowIndex];
                    cell.Style.BackColor = dlg.Color;
                    cell.Style.SelectionBackColor = dlg.Color;
                    view.CurrentCell = view.FirstDisplayedCell; \\temporarily move focus
                    view.CurrentCell = view[e.ColumnIndex, e.RowIndex]; \\put it back - this updates selectionbackcolor
                }
            }
        }
