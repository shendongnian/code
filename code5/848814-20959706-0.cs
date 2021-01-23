    SqlCommand cmd2 = new SqlCommand("getId", conn);
    cmd2.CommandType = CommandType.StoredProcedure;
    cmd2.Parameters.Add(new SqlParameter("@email", email));
    // output parm
    SqlParameter user_id = new SqlParameter("@user_id", SqlDbType.Int);
    user_id.Direction = ParameterDirection.Output;
    cmd2.Parameters.Add(user_id);
    conn.Open();
    cmd2.ExecuteNonQuery();
    conn.Close();
    Session["user_id"] = cmd2.Parameters["@user_id"].Value;
    Response.Redirect("~/CheckProfile.aspx");
