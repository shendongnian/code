    public class Shape // You can call this ShapeContainer instead
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
