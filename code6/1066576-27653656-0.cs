    public class MyFunkyClass
    {
       public ListBox ListBox { get; set;}
       public void ListDirectory(FtpClient client, string path) 
       { 
          // stuff
          Listbox.items.add(item.FullName)
          // stuff
          ListDirectory(client, item.FullName); 
       }
    }
