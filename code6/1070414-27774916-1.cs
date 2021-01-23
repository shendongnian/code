     //  foreach (GridViewRow row in grv_taskfilter.Rows)
               // {
                    for (int i = 0; i <e.row.cells.Count; i++)
                    {
                        
                        lblstatus = e.row.Cells[i].Text.ToString();//use e.rows.cell[]
    
                        if (lblstatus == "Not yet started")
                        {
                            e.Row.BackColor = System.Drawing.Color.Gray;
                        }
    
                        if (lblstatus == "In progress")
                        {
                            e.Row.BackColor = System.Drawing.Color.Orange;
                        }
    
                        if (lblstatus == "Alert")
                        {
                            e.Row.BackColor = System.Drawing.Color.Yellow;
                        }
                        if (lblstatus == "Missed deadline")
                        {
                            e.Row.BackColor = System.Drawing.Color.Red;
                        }
                        if (lblstatus == "Not Applicable")
                        {
                            e.Row.BackColor = System.Drawing.Color.BlueViolet;
                        }
                //    }
                }
            }
