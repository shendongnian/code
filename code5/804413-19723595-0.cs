    string User_ID = Session["ID"].ToString();
    string User_FirstName = FirstNameEdit.Text;
    string User_LastName = LastNameEdit.Text;
    
    query.Parameters.AddWithValue("@User_ID", Convert.ToInt32(User_ID));
    query.Parameters.AddWithValue("@User_FirstName", User_FirstName);
    query.Parameters.AddWithValue("@User_LastName", User_LastName);
    query.ExecuteNonQuery();
