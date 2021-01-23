     public class ModelTree
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IList<ModelTree>() Children {get;set;}
            public ModelTree Parent {get;set;}
        }
                            
