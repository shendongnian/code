               foreach (TableRow row in tbl.Rows)
                {
                    foreach (Table cell in row.Cells)
                    {
                        foreach (Control ctrl in cell.Controls)
                        {
                            //CONTROL IS TEXBOXT: EXTRACT VALUES//
                            if (ctrl is TextBox)
                           {
                               TextBox txt = (TextBox)ctrl;
                             Label lbl = new Label();
                             lbl.Text = txt.Text;
                             PlaceHolder1.Controls.Add(lbl);
                             }
                        }
                    }
                }
