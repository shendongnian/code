    using (MySqlDataReader Reader = cmd.ExecuteReader())
    {
        while (Reader.Read())
        {
            //Set the user's profile picture to the user's profile picture.
            ProfilePicture.Load(Reader.GetString(2));
            //Set the username to the user's username
            Username.Text = Reader.GetString(0);
            //Set the app version to the user's version
            if (Reader.GetString(1) == "1")
            {
                AppVersionLabel.Text = "Premium";
            }
            else
            {
                AppVersionLabel.Text = "Free";
            }
        }
    }
