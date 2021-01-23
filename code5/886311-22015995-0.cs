           StreamWriter sw = new StreamWriter("C:\inst_research\MonteCarlo\gridview.csv");
           foreach (GridViewRow row in InflationGridView.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    string text = "";
                    if (cell.Controls.Count > 0)
                    {
                        foreach (Control control in cell.Controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "TextBox":
                                    text = (control as TextBox).Text;
                                    break;
                                case "DropDownList":
                                    text = (control as DropDownList).SelectedItem.Text;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        text = cell.Text;
                    }
                    sw.Write(text + ',');
                }
                sw.Write("\r\n");
            }
