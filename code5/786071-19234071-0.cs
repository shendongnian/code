    SqlCommand DropCommand = new SqlCommand(DropString, con);
    SqlCommand CreateCommand = new SqlCommand(CreateString, con);
    con.Open();
    CreateCommand.ExecuteNonQuery();  // creates "dbo.students"
    DropCommand.ExecuteNonQuery();    // drops that same "dbo.students" right away ....
    con.Close();
