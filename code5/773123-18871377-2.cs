    public class Persistent
    {
        public virtual Dictionary<string, object> GetCloneDictionary()
        {
            return //dictionary containning clonning values.
        }
        public void SetValues( Dictionary<string, object> objects)
        {
           //set values from dictionary
        }
    }
    
    public class Animal : Persistent
    {
        public override Dictionary<string, object> GetCloneDictionary()
        {
            return //dictionary containning clonning values.
        }
        public override void SetValues( Dictionary<string, object> objects)
        {
        
        }
    }
    
    public class Animal2 : Animal
    {
        public override Dictionary<string, object> GetCloneDictionary()
        {
            return //dictionary containning clonning values.
        }
        public override void SetValues( Dictionary<string, object> objects)
        {
        
        }
    }
    
    
    public class PersistentClonner<T> where T : Persistent
    {
        public virtual T Clone(T obj)
        {
            obj.GetCloneDictionary();
            //create new and set values
            return //new clone
        }
    }
    
    public class AnimalClonner : PersistentClonner<Animal>
    {
        public override Animal Clone(Animal obj)
        {
            obj.GetCloneDictionary();
            //create new and set values
            return //new clone
        }
    }
