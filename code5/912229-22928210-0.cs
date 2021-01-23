     string sPhotoURL = Convert.ToString(dt.Rows[0]["PHOTO_LOCATIONColumnName"]);
                string[] words = sPhotoURL.Split(',');
                int count = 0;
                hdnImageCount.Value = words.Length.ToString();
                foreach (string word in words)
                {
                    if (word.Length > 50)
                    {
                        count += 1;
                        String correctURl = word.Substring(45);
                        string photoNumber = correctURl.Substring(1, 2);
                         correctURl = "http://" + "images-                    +photoNumber+urlsomething/somethihng/"+correctURl;
                        string url = correctURl;
    
                    }
                }
    
    This Will made  my Correct URl and after that  i pass this to Function to download Images.. 
    THank you  all i done  this by the fowllowing Code ... 
