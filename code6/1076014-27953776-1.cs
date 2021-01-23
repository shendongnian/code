    public class Matrix<T>
    {
    	public T[,] Elements { get; private set; }
    	public int XSize { get; private set; }
    	public int YSize { get; private set; }
    	public Point CentralPoint { get; set; }
    	
    	public T this [int x, int y]
    	{
    		get { return Elements[y, x]; }
    		set { Elements[y, x] = value; }
    	}
    	
    	public Matrix(int size) : this(size, size) { }
    	public Matrix(int xSize, int ySize)
    	{
    		this.XSize = xSize;
    		this.YSize = ySize;
    		this.Elements = new T[YSize, XSize];
    	}
    	
    	public T[,] Top { get { return CopySection(0, 0, XSize - 1, CentralPoint.Y); } }
    	public T[,] Bottom { get { return CopySection(0, CentralPoint.Y, XSize - 1, YSize - 1); } }
    	public T[,] Left { get { return CopySection(0, 0, CentralPoint.X, YSize - 1); } }
    	public T[,] Right { get { return CopySection(CentralPoint.X, 0, XSize - 1, YSize - 1); } }
    	
    	public T[,] FirstQuadrant { get { return CopySection(CentralPoint.X, 0, XSize - 1, CentralPoint.Y); } }
    	public T[,] SecondQuadrant { get { return CopySection(0, 0, CentralPoint.X, CentralPoint.Y); } }
    	public T[,] ThirdQuadrant { get { return CopySection(0, CentralPoint.Y, CentralPoint.X, YSize - 1); } }
    	public T[,] FourthQuadrant { get { return CopySection(CentralPoint.X, CentralPoint.Y, XSize - 1 , YSize - 1); } }
    	
    	private T[,] CopySection(int x0, int y0, int x1, int y1)
    	{
    		var result = new T[y1 - y0 + 1, x1 - x0 + 1];
    		
    		for(int x = x0; x <= x1; x++)
    			for(int y = y0; y <= y1; y++)
    				result[y - y0, x - x0] = this[x, y];
    		
    		return result;
    	}
    }
    
    public struct Point
    {
    	public int X, Y;
    	public Point(int x, int y) { this.X = x; this.Y = y; }
    }
