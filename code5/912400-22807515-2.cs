    public abstract class ListHandlerBase
    {
        public void Add(object item)
        {
            ((dynamic)this).HandleAdd((dynamic)item);
        }
    }
    
    public class ListHandler : ListHandlerBase
    {
        List<object> ObjectList = new List<object>();
        List<string> StringList = new List<string>();
        List<int> IntList = new List<int>();
    
        public void HandleAdd(object item)
        {
            ObjectList.Add(item);
        }
    
        public void HandleAdd(string item)
        {
            StringList.Add(item);
        }
    
        public void HandleAdd(int item)
        {
            IntList.Add(item);
        }
    }
