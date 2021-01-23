    public class FileManeger
    {
       public Action<string> Trace {get;set;}
       public bool ParseFile()
       {
           // ....stuff
           foreach(DataRow row in Rows)
           {
                // stuff
                this.Trace("Send a message like this");
           }
       }
    }
