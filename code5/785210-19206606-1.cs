    public class Square
    {
       // Readonly field, can only be assigned in constructor or initializer
       private readonly double _sideLength;
       // Readonly property since it only contains a getter
       public double SideLength { get { return _sideLength; } }
       // Readonly property from outside the class since the setter is private
       public double Area {get; private set;}
    
       public Square( double sideLength )
       {
            _sideLength = sideLength;
            CalcSquare();
       }
       private void CalcSquare()
       {
          this.Square = _sideLength * _sideLength;
       }
    }
