    public class Matrix<T>
    {
        public T[,] Elements { get; private set; }
        public int Size { get; private set; }
        public Point CentralPoint { get; set; }
    
        public T this [int y, int x]
        {
            get { return Elements[y, x]; }
            set { Elements[y, x] = value; }
        }
    
        public Matrix(int size)
        {
            this.Size = size;
            this.Elements = new T[Size, Size];
        }
    	
        public T[,] FirstQuadrant { get { return FromCentralTo(Size - 1, 0); } }
        public T[,] SecondQuadrant { get { return FromCentralTo(0, 0); } }
        public T[,] ThirdQuadrant { get { return FromCentralTo(0, Size - 1); } }
        public T[,] FourthQuadrant { get { return FromCentralTo(Size - 1 , Size - 1); } }
    
        private T[,] FromCentralTo(int x1, int y1, [CallerMemberName]string caller = "")
        {
    		var translate = Math.Min(Math.Abs(CentralPoint.X - x1), Math.Abs(CentralPoint.Y - y1));
    		
    		//fix the p1, so this results in a square array
    		if (Math.Abs(CentralPoint.X - x1) > translate)
    			x1 = CentralPoint.X + translate * Math.Sign(x1 - CentralPoint.X);
    		if (Math.Abs(CentralPoint.Y - y1) > translate)
    			y1 = CentralPoint.Y + translate * Math.Sign(y1 - CentralPoint.Y);
    		
    		var size = translate + 1;
    		var start = new Point(Math.Min(CentralPoint.Y, y1), Math.Min(CentralPoint.X, x1));
    		
            var result = new T[size, size];
    		for (int x = 0; x < size; x++)
    			for (int y = 0; y < size; y++)
    				result[y, x] = this[start.Y + y, start.X + x];
    				
            return result;
        }
    }
    
    public struct Point
    {
        public int X, Y;
        public Point(int y, int x) { this.X = x; this.Y = y; }
    }
----
    void Main()
    {
    	var matrix = new Matrix<int>(7);
    	matrix.CentralPoint = new Point(1, 2);
    	
    	int i = 0;
    	for(int x = 0; x < 7; x++)
    		for (int y = 0; y < 7; y++)
    			matrix[x, y] = i++;
    			
    	matrix.Elements.Dump("Matrix");
    	matrix[matrix.CentralPoint.Y, matrix.CentralPoint.X].Dump("Central");
    	matrix.FirstQuadrant.Dump("1");
    	matrix.SecondQuadrant.Dump("2");
    	matrix.ThirdQuadrant.Dump("3");
    	matrix.FourthQuadrant.Dump("4");
    }
