    public void IService{
        List<BaseObject> GetObjects();
    }
    [DataContract]
    [KnownTypes(typeof(DerivedObject))]
    public class BaseObject(){
        [DataMember]
        public void string BaseProperty{get;set;}
    }
    public class DerivedObject:BaseObject(){
        [DataMember]
        public void string DerivedProperty{get;set;}
    }
