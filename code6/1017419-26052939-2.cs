    // Child class
    public class Post : ActiveRecord
    {  
       private static readonly string CollectionName = "posts";
       public Post(): base(CollectionName){}
    }
