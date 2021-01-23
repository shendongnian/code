    void Main()
    {    		
    	List<Extended1> lst = new List<Extended1>() {new Extended1(0),
                                                     new Extended1(1),
                                                     new Extended1(2),
                                                     new Extended1(3)};
	
    	Extended2 itm = new Extended2(4);
    	List<BaseCls> items = new List<BaseCls>();    	
    	items.AddRange(lst.Cast<BaseCls>());
    	items.Add(itm);
    	Console.WriteLine(String.Join(", ",
                              items.Select(i => i.myInt.ToString()).ToArray()));
        // prints 0, 1, 2, 3, 40
    }
    
    public class BaseCls {
    	public int myInt;
    	public BaseCls(int val) {
    		myInt = val;
    	}
    }
    
    public class Extended1:BaseCls {
    	public Extended1(int val):base(val) {}
    }
    
    public class Extended2:BaseCls {
    	public Extended2(int val):base(val*10) {}
    }
