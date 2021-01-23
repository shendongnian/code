    protected void Add(object sender, EventArgs e)
    {
        var vardas = GridView1.FooterRow.FindControl("txtname") as TextBox;
        var pavarde = GridView1.FooterRow.FindControl("txtlastname") as TextBox;
        var pozymis = GridView1.FooterRow.FindControl("DropDownList2") as DropDownList;
    
        SqlCommand comm = new SqlCommand();
        comm.CommandText = "select lastname from asmenys where lastname = @lastname";
        comm.Parameters.AddWithValue("@lastname", lastname.Text);
        SqlDataReader reader = comm.ExecuteReader();
        if (reader.HasRows)
        {
            Console.WriteLine("Values exist");
        }
        else
        {
            comm.CommandText = "insert into asmenys (name,lastname, status) values(@name,@lastname, @status)";
            comm.Connection = con;
    
            comm.Parameters.AddWithValue("@name", name.Text);
            comm.Parameters.AddWithValue("@lastname", lastname.Text);
            comm.Parameters.AddWithValue("@status", status![enter image description here][1].Text);
    
            con.Open();
            comm.ExecuteNonQuery();
            con.Close();
            DataBind();
        }
    }
