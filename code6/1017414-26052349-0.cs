    // Base class
    public Class ActiveRecord {
       public virtual string CollectionName;
       public static Collection() {
           return CollectionInstance(CollectionName); // just pseudo code
       }
    }
    // Child class
    public Class Post : ActiveRecord
    {
       public override string CollectionName = "posts"; 
    }
