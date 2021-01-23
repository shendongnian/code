    public struct Position
    {
        public int x { get; set; }
    
        public int y{ get; set; }
        public string name{ get; set; }
    
    }
    foreach (Position item in positions)
    {   
         item.x = item.x + 1;
    }
