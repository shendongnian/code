    protected void Button2_Click(object sender, EventArgs e)
    {
                int i = ViewState["cnt"]!=null? (int) ViewState["cnt"]:1;
                i = i + 1;
                TextBox1.Text = GridView1.Rows[i].Cells[1].Text;
                TextBox2.Text = GridView1.Rows[i].Cells[2].Text;
                TextBox3.Text = GridView1.Rows[i].Cells[31].Text;
                TextBox4.Text = GridView1.Rows[i].Cells[5].Text;
                ViewState["cnt"] = i;
    }
