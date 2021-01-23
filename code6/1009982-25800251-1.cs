    public class DVD
    {
        public string Title{ get; set;}
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
    
        public DVD(string title, string name, string type, int length)
        {
    
            Title = title;
            Name = name;
            Type = type; 
            Length = length;
    
        }
    }
