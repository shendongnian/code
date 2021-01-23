        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["learnaspConnectionString"].ConnectionString);
        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.RegisterInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@fname", txtfname.Text);
                SqlParameter p2 = new SqlParameter("@lname", txtlname.Text);
                SqlParameter p3 = new SqlParameter("@company", txtcompany.Text);
                SqlParameter p4 = new SqlParameter("@phone", txtphone.Text);
                SqlParameter p5 = new SqlParameter("@address", txtaddress.Text);
                SqlParameter p6 = new SqlParameter("@email", txtemail.Text);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter("Select * from register",con);//Here  you are using same cmd that is for insert so you call insert procedure twice and that's why insert data twice 
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                ListViewDetails.DataSource = ds;
                ListViewDetails.DataBind();
                lblmessage.Visible = true;
                lblmessage.Text = "Registration Completed Successfully!";
                con.Close();
            }
            catch (SqlException ex)
            {
            }
        }
