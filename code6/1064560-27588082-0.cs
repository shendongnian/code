    public interface IGetTraitInfo
    {
        Type GetTraitObjectType();
        object GetTraitObject();
    }
    
    public class TraitUser<T> : IGetTraitInfo
    {
        private T _thing;
    
        public void DoThingWithT(T thing) 
        {
            _thing = thing;
        }
    
        public Type GetTraintObjectType()
        {
            return typeof(T);
        }
    
        public Type GetTraitObject()
        {
            return _thing;
        }
    }
    
    public class TrairInspector 
    {
        public void InspectTraitUser(IGetTraitInfo traitUser) 
        {
            Type traitType = traitUser.GetTraintObjectType();
            object data = traitUser.GetTraitObject();
        }
    }
