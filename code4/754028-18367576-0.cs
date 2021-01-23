    public void DisplayEditors(DataGridView grid, DataGridViewRow row)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ReadOnly == false)
                    {
                        var place = grid.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                        var name = string.Format("EDITOR-{0}-{1}", cell.ColumnIndex, cell.RowIndex);
                        var editor = grid.Controls.Find(name, false).FirstOrDefault();
    
                        if (editor == null)
                        {
                            editor = new TextBox();
    
                            (editor as TextBox).Name = name;
    
                            grid.Controls.Add(editor);
                        }
                        else
                        {
                            editor.Show();
                        }
    
                        editor.Size = place.Size;
                        editor.Location = place.Location;
                        editor.Text = Convert.ToString(cell.Value);
                    }
                }
            }
