     protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("CheckBox1");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        // process selected record
                        Response.Write(item.Cells[1].Text + "<br>");
                    }
                }
            }
        }
