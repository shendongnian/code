    public class MyFunkyClass
    { 
    
        public void ListDirectory(FtpClient client, string path, Action<string> myAction) 
        { 
              // stuff
              myAction(item.FullName)
              // stuff
              ListDirectory(client, item.FullName, action); 
        }
    
    }
