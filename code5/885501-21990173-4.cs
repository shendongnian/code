    public class MyBaseClass
    {
    	private readonly MySubClass1 _sub1 = new MySubClass1();
    	private readonly MySubClass2 _sub2 = new MySubClass2();
    	
    	public void DoMyWork()
    	{
    		_sub1.DoSubClass1();
    		_sub2.DoSubClass2();
    	}
    }
    
    public class MySubClass1
    {
    	public void DoSubClass1() { /* Do stuff */ }
    }
    
    public class MySubClass2
    {
    	public void DoSubClass2() { /* Do stuff */ }
    }
