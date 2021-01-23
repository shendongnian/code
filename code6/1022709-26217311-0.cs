    // choose a better name and make the properties read-only (get;} if necessary
    public interface ILevelItem  
    {
        public int XPos {get; set;}
        public int YPos {get; set;}
        public SolidBrush Brush {get; set;}
    }
    
    public class Wall : ILevelItem
    {
        ....
    }
    
    public class Obstacle : ILevelItem
    {
        ....
    }
