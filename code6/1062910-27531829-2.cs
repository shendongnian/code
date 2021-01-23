    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		ViewModel _model = new ViewModel();
    		
    		_model.Bs.ForEach(fe => fe.As = PlaceHolderAsData());
    
    	}
    	
    	public static List<A> PlaceHolderAsData()
    	{
    		return new List<A>()
    		{
    			new A()
    			{
    				Name = "blah blah"
    			},
    			new A()
    			{
    				Name = "Bob Loblaw"
    			}
    		};
    	}
    	
    }
    
    public class A
    {
    	public int ID {get; set; }
    	public string Name { get; set; }
    }
    
    public class B
    {
    	public List<A> As { get; set; }
    	public int ID { get; set; }
    	public string Name { get; set; }
    	
    	public B()
    	{
    		As = new List<A>();
    	}
    }
    
    public class ViewModel
    {
    	public List<B> Bs { get; set; }
    	
    	public ViewModel()
    	{
    		Bs = new List<B>()
    		{
    			new B()
    			{
    				As = new List<A>()
    			},
    			new B()
    			{
    				As = new List<A>()
    			}
    		};
    	}
    }
