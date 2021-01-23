    protected void btn_modify_Click(object sender, EventArgs e)
    {
        GridView1.Columns[1].Visible = false;
        GridView1.Columns[0].Visible = false;
        if (CheckBox2.Checked)
        {
            TextBox3.Enabled = false;
            //GridView1.Visible = false; --> Hides the whole Gridview
            this.GridView1.Columns[2].Visible = false;
            //GridView1.Columns.RemoveAt(2);
        }
        else
        {
            TextBox3.Enabled = true;
            GridView1.Visible = true;
            this.GridView1.Columns[2].Visible = true;
        }
    }
        
