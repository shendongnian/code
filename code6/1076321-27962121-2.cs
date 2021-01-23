     if (e.Row.RowType == DataControlRowType.DataRow)
          {
             
                  for (int i = 0; i < e.Row.Cells.Count; i++)
                  {
                      Label lbl1 = (Label)e.Row.FindControl("lbl_Question_Scripting");//use e.rows.cell[]
                      if (lbl1.Text == "Not yet started")
                      {
                          e.Row.Cells[i].BackColor = Color.Gray;
                      }
                      if (lbl1.Text == "In progress")
                      {
                          e.Row.Cells[i].BackColor = Color.Orange;
                      }
                      if (lbl1.Text == "Alert")
                      {
                          e.Row.Cells[i].BackColor = Color.Yellow;
                      }
                      if (lbl1.Text == "Missed deadline")
                      {
                          e.Row.Cells[i].ForeColor = Color.Red;
                          // e.Row.Cells[i].BackColor = Color.Red;
                      }
                      if (lbl1.Text == "Not Applicable")
                      {
                          e.Row.Cells[i].BackColor = Color.BlueViolet;
                      }
                
              }
          }
