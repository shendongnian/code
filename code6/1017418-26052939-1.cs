    // Base class
    public class ActiveRecord {
    
       public ActiveRecord(string name) {
           CollectionInstance = new CollectionInstance(name); // just pseudo code
       }
    }
    
    // Child class
    public class Post : ActiveRecord
    {
       public Post(): base("posts"){}
    }
