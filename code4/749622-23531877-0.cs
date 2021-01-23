    public class ObjectWithExtraFields {
        public Type1 O { get; set; }        
        public Dictionary<string, Type2> ExtraFields { get; set; }
    }
    var collection = database.GetCollection<ObjectWithExtraFields>(o.GetType().Name + "s");
    collection.Insert(new ObjectWithExtraFields {    
        O = o,
        ExtraFields = ExtraFields
    });
