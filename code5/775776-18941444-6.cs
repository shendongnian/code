    // Ask to return just the data you need, not the whole rows
    string commandText = "select name,address from detail where contact_no = @num");
    using(SqlConnection con = new SqlConnection(....))
    using(SqlCommand cmd = new SqlCommand(commandText, con))
    {
         con.Open();
         cmd.Parameters.AddWithValue("@num", Convert.ToInt32(TexBo_num.Text));
         using(SqlDataAdapter value = new SqlDataAdapter(cmd))
         {
             DataSet val = new DataSet();
             value.Fill(val);
             if (val.Tables[0].Rows.Count > 0)
             {
                 TxtBox_name.Text = val.Tables[0].Rows[0]["name"].ToString();
                 TexBo_add.Text  = val.Tables[0].Rows[0]["address"].ToString();
             }
             else
                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('value not found');", true);
         }
     }
