    var highScore = 99;
    var username = "johndoe";
    OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
    string insertCommand = @"INSERT INTO scores (id, highscore)
                            SELECT id, " + highScore + " FROM users WHERE username = ?;";
    
    OleDbCommand cmd = new OleDbCommand(insertCommand, con);
    cmd.Parameters.Add("@username", OleDbType.VarChar, 80).Value = username;
    con.Open();
    cmd.ExecuteNonQuery();
    con.Close();
