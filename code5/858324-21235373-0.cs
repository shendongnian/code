    public struct Point
    {
        public int X;
        public int Y;
        public Point( int x, int y )
        {
            X = x;
            Y = y;
        }
    }
    public class Whatever
    {
        // ...
        // Here is a list of the positions of all the neighbours whose values are
        // zero.
        List<Point> zeroPositions = new List<Point>();
        // ...
        public int Modificari(int pointX, int pointY)
        {
            // Determine dimensions of array.
            int height = mat.GetLength(0);
            int width = mat.GetLength(1);
            // Find the minimum and maximum positions bounded by array size. (So we
            // don't try to look at cell (-1, -1) when considering the neighbours of
            // cell (0, 0) for instance.
            int left = Math.Max( pointX - 1, 0 );
            int right = Math.Min( pointX + 1, width );
            int top = Math.Max( pointY - 1, 0 );
            int bottom = Math.Min( pointY + 1, height );
            
            // This is the number of neighbours whose value is 1.
            int oneCount = 0;
            zeroPositions.Clear();
            for( int y = top; y <= bottom; y++ )
            {
                for( int x = left; x <= right; x++ )
                {
                    if( mat[x, y] == 1 )
                    {
                        oneCount++;
                    }
                    else if( mat[x, y] == 0 )
                    {
                        zeroPositions.Add( new Point( x, y ) );
                    }
                }
            }
            return oneCount;
        }
        //...
    }
