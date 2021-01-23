    //Initialize your panel first here
    //.....
    //.....
    string cmdText = "SELECT (FirstName + ' ' + MiddleName + ' ' + LastName) as FullName, " +
                     "imgPath as ImagePath FROM TableVote WHERE Position='President'";
    using(SqlCommand com = new SqlCommand(cmdText,sc)){
       is(sc.State != ConnectionState.Open) sc.Open();
       SqlDataReader reader = com.ExecuteReader();       
       while(reader.Read()){
         AddRadioButton(reader.GetString(0), reader.GetString(1));
       }
       reader.Close();
       sc.Close();
    }
    //...
    private void AddRadioButton(string fullName, string imagePath){
       RadioButton radio = new RadioButton {Text = fullName, Parent = panel};
       radio.Image = new Bitmap(Image.FromFile(imagePath),75,75);
       radio.TextImageRelation = TextImageRelation.ImageAboveText;       
    }
