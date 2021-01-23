        protected void Button1_Click(object sender, EventArgs e)
        {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        //use a sqlparameter to avoid the possibility of sql injection
        SqlParameter p = new SqlParameter("p1", ddlClients.SelectedValue);
        cmd.Parameters.Add(p);
        cmd.CommandText = "insert into cascad(Client) values(@p1)";
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Cascad.aspx");
        }
