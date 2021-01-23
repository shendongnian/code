    //Code to delete multiple files. It will delete all files created one hour back
        void Session_End(object sender, EventArgs e)
            {
        string[] str = System.IO.Directory.GetFiles("Your file path");
                    for (int i = 0; i < str.Length; i++)
                    {
                       
                            DateTime dt = System.IO.File.GetCreationTime(str[i]);
                            if (dt < DateTime.Now.AddHours(-1))
                                System.IO.File.Delete(str[i]);
        
                    }
        }
