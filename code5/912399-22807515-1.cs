    public abstract class ListHandlerBase
    {
        public abstract void Add(object item);
    }
    
    public class ListHandler : ListHandlerBase
    {
        …
        public override void Add(object item)
        {
            HandleAdd((dynamic)item);
        }
    
        …
    }
