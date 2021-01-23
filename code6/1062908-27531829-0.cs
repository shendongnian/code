    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		ViewModel _model = new ViewModel();
    		var AllOfMyAs = _model.Bs.SelectMany(sm => sm.As).ToList(); // Here's the "main event"
    		
    		Console.WriteLine(AllOfMyAs.Count());
    		Console.WriteLine("");
    		foreach (A a in AllOfMyAs)
    		{
    			Console.WriteLine(a.Name);
    		}
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
    				{
    					new A()
    					{
    						Name = "test1"
    					},
    					new A()
    					{
    						Name = "test2"
    					}
    				}				
    			},
    			new B()
    			{
    				As = new List<A>()
    				{
    					new A()
    					{
    						Name = "another B"
    					}
    				}
    			}
    		};
    	}
    }
