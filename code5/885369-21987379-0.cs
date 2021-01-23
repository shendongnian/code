    void Main()
    {
    	var boxes = new List<Box>()
    	{
    	  new Box(1, 2, 2, 2),
    	  new Box(2, 2, 2, 2),
    	  new Box(3, 3, 3, 3),
    	  new Box(4, 3, 3, 3),
    	  new Box(5, 4, 4, 4)
    	};
    	
    	var groupedBoxes = boxes.GroupBy (b => new {b.depth, b.height, b.length}).Dump();
    }
    
    // Define other methods and classes here
    public class Box
    {
      public Box(int bno, int len, int hei, int dep)
      {
        this.bno = bno; this.length = len; 
        this.height = hei; this.depth = dep; 
        //assuming volume is result of former 3 properties
        this.volume = length * depth * height;
      }
    	
    	
    	public int bno { get; set; }
    	public int length { get; set; }
    	public int height { get; set; }
    	public int depth { get; set; }
    	public int volume { get; set; }
    }
