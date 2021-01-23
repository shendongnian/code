    public class MyFunkyClass
    { 
    
        public void ListDirectory(FtpClient client, string path, Action<string> myAction) 
        { 
              // stuff
              myAction(item.FullName)
              // stuff
              ListDirectory(client, item.FullName, myAction); 
        }
    
    }
    // Usage
    
    var myFunkyClass = new MyFunkyClass() 
    
    Action<string> myAction = (value) => {
       listBox1.Items.Add(value);
    };
    
    myFunkyClass.ListDirectory(client,path,myAction);
    // or
    myFunkyClass.ListDirectory(client,path, value => listBox1.Items.Add(value));
