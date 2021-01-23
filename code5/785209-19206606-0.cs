    public class Square
    {
       public double Area {get; private set;}
    
       private readonly double _sideLength;
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
