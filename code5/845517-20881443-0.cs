    try {
           DirectoryEntry Discover = new DirectoryEntry("WinNT://Workgroup");  **//Error occured here**
            foreach (DirectoryEntry Node in Discover.Children)
            {                
                    if (Node.Properties.Count > 0)
                    {
                        //you have access to the computer so yeah
                    }
             }
        }
       catch(System.IO.FileNotFoundException err) 
       {
                    var ErrorMesage = err.Message;
                    //Yeah you dont have access to this computer, lets write a subroutine to allow the user to put in a username and password to access it
       }
