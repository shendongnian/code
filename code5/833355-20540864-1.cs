    using (var con =new MySqlConnection(WebConfigurationManager.ConnectionStrings["ComeVoxConnectionString"].ToString()))
    {
        
        var userStream = new List<streamData>();
        //string cmdText = "SELECT m.id, s.avatar, s.username, m.title, m.path, m.description, m.date FROM users s, musics m WHERE (musics.userID = users.id)";
        string cmdText =
            "SELECT musics.id as MID, users.avatar as UserPic, users.username as userName, musics.title as MTitle, musics.path as MusicPath, musics.description as Mdesc, musics.date as MDate FROM `users`, `musics` WHERE musics.userID = users.id;";
        con.Open();
        using (var cmd = new MySqlCommand(cmdText, con))
        {
            using (MySqlDataReader myReader = cmd.ExecuteReader())
            {
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        var user_stream = new streamData();
                        user_stream.musicID = Convert.ToInt32(myReader["MID"].ToString());
                        user_stream.Title = myReader["MTitle"].ToString();
                        user_stream.FilePath = myReader["MusicPath"].ToString();
                        user_stream.desc = myReader["Mdesc"].ToString();
                        user_stream.Artists = myReader["userName"].ToString();
                        user_stream.releaseDate = Convert.ToDateTime(myReader["MDate"].ToString());
                        user_stream.imgUrl = myReader["UserPic"].ToString();
                        userStream.Add(user_stream);
                    }
                }
            }
        }
    }
