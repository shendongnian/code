    public class Shape
    {
     public int x { get; set; }
     public int y { get; set; }
    
     public ISpecificShapeData SpecificData { get; set; }
    }
    
    public class TriangleData : ISpecificShapeData 
    {
    // ...
    // ...
    }
    
    public class RectangeData : ISpecificShapeData 
    {
    // ...
    // ...
    }
