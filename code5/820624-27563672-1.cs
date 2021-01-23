    protected void EnableTextBox()
    {
        int count = int.Parse(GridView1.Rows.Count.ToString());
        for (int i = 0; i < count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
            CheckBox cb1 = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox2");
            CheckBox cb2 = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox3");
            TextBox tb = (TextBox)GridView1.Rows[i].Cells[4].FindControl("txtration");
            TextBox tb1 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("txtjob");
            TextBox tb2 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("txtaadhar");
            
            if (cb.Checked == true)
            {
                tb.Visible = true;               
            }
            else
            {
                tb.Visible = false;
            }
            if (cb1.Checked == true)
            {
                tb1.Visible = true;                
            }
            else
            {
                tb1.Visible = false;              
            }
            if (cb2.Checked == true)
            {
                tb2.Visible = true;               
            }
            else
            {
                tb2.Visible = false;
            }
        }
    }
