    protected void Button2_Click(object sender, EventArgs e)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if ((row.FindControl("CheckBox1") as CheckBox).Checked)
                    {
                        TextBox1.Text = row.Cells[0].Text;
                        TextBox2.Text = row.Cells[1].Text;
                        TextBox3.Text = row.Cells[2].Text;
                    }
                }
            }
