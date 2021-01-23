     if (e.ColumnIndex != -1 && e.RowIndex != -1 && dataGridView1.Columns[e.ColumnIndex].HeaderText == "TEXTBOX")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Icon ico = new Icon("your_filename.ico");
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + ((dataGridView1.Columns[e.ColumnIndex].Width - 16) / 2), e.CellBounds.Top + 3);
                e.Handled = true;
            }
