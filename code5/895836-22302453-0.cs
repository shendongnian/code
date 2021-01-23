    public class Foo {
    	private FooBar _someVar;
    	protected FooBar SomeVar {
    		get { return _someVar; }
    		set {
    			if (_someVar != value) {
    				_someVar = value; 
    				OnSomeVarUpdated();
    			}
    		}
    	}
    	
    	protected event EventHandler SomeVarUpdated;
    	private void OnSomeVarUpdated() {
    		var someVarUpdated = SomeVarUpdate;
    		if (someVarUpdated != null) {
    			someVarUpdated(this, EventArgs.Empty);
    		}
    	}
    
    	public virtual void DoSomething() {
    	   // Manipulate SomeVar here
    	   var someVar = ....;
    	   SomeVar = someVar;
    	}
    }
    
    public class Foo<T>: Foo where T: SomeObject {
    	public Foo() {
    		OnSomeVarUpdated += () => {
                // Pull new value from base
    			SomeVar = (FooBar<T>)base.SomeVar;
    		};
    	}
    	
    	private FooBar<T> _someVar;
    	protected new FooBar<T> SomeVar {
    		get { return _someVar; }
    		set {
    			if (_someVar != value) {
    				_someVar = value;
                    // Push new value to base
    				base.SomeVar = value;
    			}
    		}
    	}
    }
