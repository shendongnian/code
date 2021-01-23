       public class Model
        {
            public List<Model> ChildModels { get; set; }
            [UniqueId]
            public Guid ModelId { set; get; }
            public Guid ? ParentId { set; get; }
            public List<SomeOtherObject> OtherObjects { set; get; }
        }
