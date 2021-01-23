    protected void Button1_Click(object sender, EventArgs e){
        try{
                con.Open();
                string IdText = user.Text;
                string PassText = pass.Text;
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(Id, '') AS Id, ISNULL(Pass,'') AS Pass FROM Students WHERE Id = @Id and Pass = @Pass", con);
                cmd.Parameters.Add(new SqlParameter("@Id", IdText));
                cmd.Parameters.Add(new SqlParameter("@Pass", PassText));
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();       
             
				dr.Read();
				if (dr["Id"].ToString().Trim() == IdText && dr["Pass"].ToString().Trim() == PassText) {
					Response.Redirect("Main.aspx");
				}
				else
				{
					Label4.Text = "Invalid Username or Password";
				}             
                dr.Close();
                con.Close();
            }
            catch (Exception ex){
                Label4.Text = (ex.Message);
            }
        } 
    }
