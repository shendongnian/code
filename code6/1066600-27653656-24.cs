    public class MyFunkyClass
    { 
        public delegate void MyDelegate(string value);
        public void ListDirectory(FtpClient client, string path, MyDelegate myDelegate) 
        { 
              // stuff
              myDelegate(item.FullName)
              // stuff
              ListDirectory(client, item.FullName, myDelegate); 
        }
    
    }
    // Usage
    var myFunkyClass = new MyFunkyClass() 
    myFunkyClass.ListDirectory(client, path, value => listBox1.Items.Add(value)));
