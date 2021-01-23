    public class MyDynamicObject : DynamicObject {
    	public override bool TryGetMember(GetMemberBinder binder, out Object result){
    		if (binder.Name == "myVar"){
    			result = "xyz";
    			return true;
    		}			
    		
    		result = null;
    		return false;
    	}
    }
    
    // Usage
    dynamic x = new MyDynamicObject();
    Console.WriteLine (x.myVar); // will output "xyz"
