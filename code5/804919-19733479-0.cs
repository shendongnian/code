    using(SqlConnection con = new SqlConnection("connectionstring"))
    using(SqlCommand cmd = new SqlCommand("Insert into NOTESMAKER(NOTESMAKER) Values(@NotesMaker)",con))
    {
        cmd.Parameters.AddWithValue("@NotesMaker", NotesMaker);
        con.Open();
        cmd.ExecuteNonQuery();
    } 
