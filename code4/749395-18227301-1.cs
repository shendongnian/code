    public class SimplePoco
    {
        [GeneratedByDatabase]
        public int Id { get; set; }
    
        [GeneratedByDatabase]
        public int RowVersion { get; set; }
    
        public string Name { get; set; }
    }
