    public class MyFunkyClass
    {    
        public void ListDirectory(FtpClient client, string path, Listbox listbox) 
        { 
              // stuff
              listbox.Items.Add(item.FullName))       
              // stuff
              ListDirectory(client, item.FullName, listbox); 
        }
    }
    // Usage
   
    var myFunkyClass = new MyFunkyClass() 
    
    myFunkyClass.ListDirectory(client,path,listBox1);
