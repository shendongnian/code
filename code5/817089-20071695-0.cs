    // This can represent any function that takes nothing and returns a point.
    public delegate Point Mobile();
    public class Program {
        // This takes any "Mobile" function, calls it and displays the result.      
        public void mth(Mobile getPosition) {
            Point p = getPosition();
            Console.WriteLine("{ " + p.x + ", " + p.y + " }");
        }
        // This calls mth with a lambda that matches the "Mobile" definition.
        static void Main( string[] args ) {
            new Program().mth(() => { return new Point( 4, 5 ); }); 
        }
    }
