    void Main()
    {
    	var f=new Foo();
    	f.FillMyList();
    }
    
    public class Foo
    {
    	public List<string> MyList { get; set; }
    }
    
    public static class extensions
    {
    	public static void FillMyList(this Foo f)
    	{
    		f.MyList=new List<string>();
    		f.MyList.Add("some item");
    	}
    }
