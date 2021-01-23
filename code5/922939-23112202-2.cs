    public class ShapeContainer 
    {
     public int x { get; set; }
     public int y { get; set; }
    
     public ISpecificShape SpecificShape { get; set; }
    }
    
    public class Triangle : ISpecificShape 
    {
    // ...
    // ...
    }
    
    public class Rectange : ISpecificShape 
    {
    // ...
    // ...
    }
