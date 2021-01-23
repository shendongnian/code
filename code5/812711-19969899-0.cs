         foreach (GridViewRow row in GridView1.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    foreach (var control in cell.Controls)
                    {
                        var box = control as TextBox;
                        if (box != null )
                        {
                            box.Text = string.Empty;
                        }
                    }
                }
            }
