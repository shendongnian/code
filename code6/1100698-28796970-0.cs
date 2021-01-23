    for (int i = 0; i < GridView1.Rows.Count; ++i)
            {
          Label lblcredit = GridView1.Rows[i].FindControl("credit") as Label;
                if (lblcredit.Text == "credit")
                {
                    sumCredit += Convert.ToDouble(GridView1.Rows[i].Cells[4].Text);
                    TxtCredit.Text = sumCredit.ToString();
                }
                else
                {
                    sumDebit += Convert.ToDouble(GridView1.Rows[i].Cells[4].Text);
                    TxtDebit.Text = sumDebit.ToString();
                }
            }
