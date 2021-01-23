       public class Mobile {
          public Func<Point> GetPosition;
       }
    
       public class Program {
          public void mth( Mobile mobile ) {
             Point p = mobile.GetPosition();
             Console.WriteLine( "{ " + p.x + ", " + p.y + " }" );
          }
    
          static void Main( string[] args ) {
             new Program().mth( new Mobile { GetPosition = () => { return new Point( 4, 5 ); } } ); 
          }
       }
