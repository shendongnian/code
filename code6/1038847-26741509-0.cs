    using (SqlConnection con = new SqlConnection(ct))
    {
       using (SqlCommand cmnd = new SqlCommand("spupdateuserprofiledetails", con))
       { 
          cmnd.CommandType = CommandType.StoredProcedure;
          string userName  = HttpContext.Current.User.Identity.Name.ToString();
          cmnd.Parameters.AddWithValue("@FirstName", firstnametext.Text));
          cmnd.Parameters.AddWithValue("@LastName", lastnametext.Text));
          cmnd.Parameters.AddWithValue("@Dateofbirth", dobtext.Text));
          cmnd.Parameters.AddWithValue("@ContactNo", contacttext.Text));
          cmnd.Parameters.AddWithValue("@Username", userName));
          // Or If you are planning to use the `Add` method instead of the `AddWithValues` then make sure you explicitly specify the type of the parameter you pass to the stored procedure.
          // cmnd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstnametext.Text;
          // cmnd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastnametext.Text;
          // and so on
          con.Open();
          cmnd.ExecuteNonQuery();
       }
    }
