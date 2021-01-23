       public class Square
       {
            public Square(double lengths)
            {
               Length = lengths;
               Area = computeArea();
            }
            //Read only property for Length (privately settable)
            public double Length {get; private set;}
            //Read only property for Area (privately settable)
            public double Area {get; private set;}
            
            //Private method to compute area.
            private double ComputeArea()
            {
                return Length * Length;
            }
        }
