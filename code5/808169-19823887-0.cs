    void Main()
    {
    	var myObj = new SomeClass();
    	PrintProperties(myObj);
    	
    	myObj.test = "haha";
    	PrintProperties(myObj);
    }
    
    private void PrintProperties(SomeClass myObj){
     	foreach(var prop in myObj.GetType().GetProperties()){
    	 Console.WriteLine (prop.Name + ": " + prop.GetValue(myObj, null));
    	}
     
        foreach(var field in myObj.GetType().GetFields()){
         Console.WriteLine (field.Name + ": " + field.GetValue(myObj));
        }
    }
    
    public class SomeClass {
     public string test {get; set; }
     public string test2 {get; set; }
     public int test3 {get;set;}
     public int test4;
    }
