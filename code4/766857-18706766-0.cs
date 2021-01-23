    public class DelayedUpdateCollection<U>: ICollection<U> 
    {
       
        ICollection<U> collection;
        
    
        public DelayedUpdateCollection(ICollection<U> coll){
            collection = coll;
        }
    
        ...
