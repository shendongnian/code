    While(Reader.Read()){
       //Set the user's profile picture to the user's profile picture.
       string UserProfilePictureLocation = Reader.GetString(3);
       ProfilePicture.Load(UserProfilePictureLocation);
       //Set the username to the user's username
       Username.Text = Reader.GetString(0);
       //Set the app version to the user's version
       if (Reader.GetString(2) == "1")
       {
            AppVersionLabel.Text = "Premium";
       }
       else
       {
            AppVersionLabel.Text = "Free";
       }
    }
