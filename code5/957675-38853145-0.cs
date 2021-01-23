    [DataContract]
        public class Recipe
        {
            public Recipe()
            {
                Title = "";
                Description = "";
                CategoryId = "";
                Cost = cost;
                ProductList = new List<string>();
            }
    
            [BsonId]
            public ObjectId _id { get; set; }
    
            [DataMember]
            public string Id
            {
                get { return _id.ToString(); }
                set { _id = ObjectId.Parse(value); }
            }    
    
            [DataMember]
            public string Title { get; set; }
        
            [DataMember]
            public string Description { get; set; }
        
            [DataMember]
            public int Cost { get; set; }
        
            [DataMember]
            public string CategoryId { get; set; }
        
            [DataMember]
            public List<string> ProductList { get; set; }  
        }
