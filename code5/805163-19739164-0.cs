      for(int rows=0;rows<Table1.Rows.Count;rows++)
                {
                    for (int cols = 0; cols < Table1.Rows[rows].Cells.Count; cols++)
                    {
                        if (Convert.ToInt32(Table1.Rows[rows].Cells[cols].Text.ToString()) == 1)
                        {
                            Table1.Rows[rows].Cells[cols].BackColor = Color.Green;
                        }
                        else if (Convert.ToInt32(Table1.Rows[rows].Cells[cols].Text.ToString()) == 0)
                        {
                            Table1.Rows[rows].Cells[cols].BackColor = Color.Red;
                        }
                    }
                }
