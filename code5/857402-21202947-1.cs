    class Square : Shape
    {
      public Square(int sideLength)
      {
        this.Sides = 4;
        this.SideLength = sideLength;
      }
    
      public int SideLength{get;private set;}
    
      public override int CalculateArea()
      {
        return this.SideLength * this.SideLength
      }
    }
