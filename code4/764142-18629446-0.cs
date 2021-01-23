    class Things
    {
        public string Name {get;set;}
        public string User { get; set; }
        public ObjectId Id { get; set; }
    
        public virtual Dictionary<string, Detail> Details { get; set; }
    }
    
    class Pc:Things
    {
        public new Dictionary<string, Detail> Details { 
         // supply another way of creating the dictionary? 
         //Does not make sense from your example
        }
    }
    
    class Detail
    {
        public string cpu { get; set; }
        public int ram { get; set; }
        public int hdd { get; set; }
    } 
