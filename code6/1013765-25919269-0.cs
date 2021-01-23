    public abstract class MyClass{
    	 private SomeObject _obj ; 
         public SomeObject Obj {get { return  _obj ?? (_obj = InitializeObj() );}} //no setter needed
         protected abstract SomeObject InitializeObj();
    }
    
    public class MyRealClass:MyClass {
        protected override SomeObject InitializeObj(){
        	return new VerySpecialSomeObject(this, other, another, 1, 2 , false, option: new Options());
        }	
    }
