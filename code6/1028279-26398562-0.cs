    public class ConsolidatedData
    {
        public int Id { get; set; }
        [NotNull]
        public object PropertyOne { get; set; }
        [NotNull]
        public object PropertyTwo { get; set; }
    }
    
    public class NotNull : Attribute {    }
