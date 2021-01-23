     for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (GridView1.Rows.Count % 2 == 0)
                        {
                            e.Row.Cells[0].BackColor = System.Drawing.Color.Green;
                            e.Row.Cells[1].BackColor = System.Drawing.Color.Green;
                       
                        }
                        else
                        {
                            e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                        }
     
                    }
