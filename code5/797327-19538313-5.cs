    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
    HiddenField45.Value = "No";
    Label61.Text = HiddenField19.Value;
    Label91.Text = HiddenField20.Value;
    if (Label91.Text == "")
    {
        Label91.Text = "a1 Like '' OR ";
        GridView1.Columns[10].Visible = false;
    }
    else
    {
    }
    Label101.Text = Label91.Text.Remove(Label91.Text.Length - 4);
    //datalist1 attributes
    String a1 = ((Label)e.Item.FindControl("a1Label")).Text;
    String b1 = ((Label)e.Item.FindControl("b1Label")).Text;
    String c1 = ((DropDownList)e.Item.FindControl("c1DropDownList")).Text;
    String d1 = ((TextBox)e.Item.FindControl("d1TextBox")).Text;
    
    //datalist2 attributes
     String a2 = ((Label)DataList2.Items[0].FindControl("a2Label")).Text; 
     String b2 = ((Label)DataList2.Items[1].FindControl("b2Label")).Text;
     String c2 = ((DropDownList)DataList2.Items[2].FindControl("c2DropDownList")).Text;
     String d2 = ((TextBox)DataList2.Items[3].FindControl("d2TextBox")).Text;
    //here [0],[1],[2],[3] denote row numbers.
    string str = "UPDATE table1 SET a1=@a1, b1=@b1, c1=@c1, d1=@d1 WHERE a1=@a1 AND b1=@b1";
    using (MySqlConnection con = new MySqlConnection("Server=mysql.xxxxxxxx;Port=xxxx; Database=xxxxxxx; User=xxxxxxx; Password=xxxxxxx;"))
    {
        using (MySqlCommand cmd = new MySqlCommand(str, con))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@a1", a1);
            cmd.Parameters.AddWithValue("@b1", b1);
            cmd.Parameters.AddWithValue("@c1", c1);
            cmd.Parameters.AddWithValue("@d1", d1);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    //datalist2 update()
    string str2 = "UPDATE table2 SET a2=@a2, b2=@b2, c2=@c2, d2=@d2 WHERE a2=@a2 AND b2=@b2";
    using (MySqlConnection con2 = new MySqlConnection("Server=mysql.xxxxxxx;Port=xxxx; Database=xxxxxxx; User=xxxx; Password=xxxxxx;"))
    {
        using (MySqlCommand cmd2 = new MySqlCommand(str2, con2))
        {
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.AddWithValue("@a2", a2);
            cmd2.Parameters.AddWithValue("@b2", b2);
            cmd2.Parameters.AddWithValue("@c2", c2);
            cmd2.Parameters.AddWithValue("@d2", d2);
            con2.Open();
            cmd2.ExecuteNonQuery();
        }
    }
    for (int i = 0; i < GridView3.Rows.Count; i++)
    {
        GridView grid = (GridView)GridView3.Rows[i].Cells[21].FindControl("GridView8");
        grid.DataBind();
    } 
    }
