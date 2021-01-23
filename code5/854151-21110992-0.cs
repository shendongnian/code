    public bool Addcomment(string Post_ID, string User_ID, string Comment_Content, DateTime Comment_Add_Date, DateTime Comment_Last_Date, bool Comment_Flag)
    {
        SqlCommand cmd = new SqlCommand("dbo.Insertintocomments");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Post_ID", Post_ID);
        cmd.Parameters.AddWithValue("@User_ID", User_ID);
        Comment_Content = Comment_Content.Contains(",") ? Comment_Content.Replace(",", null) : Comment_Content;
        cmd.Parameters.AddWithValue("@Comment_Content", Comment_Content);
        cmd.Parameters.AddWithValue("@Comment_Add_Date", Comment_Add_Date);
        cmd.Parameters.AddWithValue("@Comment_Last_Date", Comment_Last_Date);
        cmd.Parameters.AddWithValue("@Comment_Flag", Comment_Flag);
        return DBHelper.Instance().Insert(cmd);
    }
