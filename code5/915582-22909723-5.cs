    void Main()
    {
      new Test().Get<ChildA>().First().Talk();
    }
    
    class Test {
    	    
    	    internal List<IEnumerable<Parent>> ManagerTemplates;
    		private ObservableCollection<IEnumerable<Parent>> ManagerListStack;
    		
    		public Test() {
    		this.ManagerTemplates = new List<IEnumerable<Parent>>
    	    {
    	        new ObservableCollection<ChildA>(){ new ChildA()},
    	        new ObservableCollection<ChildB>(){ new ChildB()},
    	    };
    		
    		 this.ManagerListStack = new ObservableCollection<IEnumerable<Parent>>(this.ManagerTemplates);
    		 }
    	
    	    public ObservableCollection<U> Get<U>() where U : Parent {
    	      return (ObservableCollection<U>)ManagerListStack.FirstOrDefault(inner => inner is ObservableCollection<U>);
    	    }
    }
    
    abstract class Parent {
    	abstract public void Talk();
    }
    
    class ChildA : Parent {
    	public override void Talk(){
    	  Console.WriteLine("I'm an A");
    	}
    
    }
    
    class ChildB : Parent {
    public override void Talk(){
    	  Console.WriteLine("I'm a B");
    	}
    }
