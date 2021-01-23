    public class Triangle
    {
        public string Colour { get; set; }
    }
    
    public Triangle GetTriangle(bool isBlue)
    {
        Triangle resultTriangle;
    
        if (isBlue)
        {
            resultTriangle = new Triangle { Colour = "Blue" };
        }
        else
        {
            resultTriangle = new Triangle { Colour = "Red" };
        }
    
        return resultTriangle;
    }
	
