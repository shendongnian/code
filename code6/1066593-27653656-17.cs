    public class MyFunkyClass
    {
       public ListBox ListBox { get; set;}
       public void ListDirectory(FtpClient client, string path) 
       { 
          // stuff
          Listbox.Items.Add(item.FullName)
          // stuff
          ListDirectory(client, item.FullName); 
       }
    }
    // Usage
    var myFunkyClass = new MyFunkyClass() { ListBox = listBox1} 
    
    myFunkyClass.ListDirectory(client,path);
