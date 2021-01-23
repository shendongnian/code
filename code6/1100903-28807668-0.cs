    public static void Check(int n1, int n2, Expression<Func< int, int, bool>> exp)
    {
       var compiled = exp.Compile();                      
       Console.WriteLine("Expression: " + exp.Body.ToString() + "\t Result: " + compiled.DynamicInvoke(n1,n2)); 
    }
    	
    public void Test_1(){
        int a = 2, b = 3;
       Check(a,b, (x,y)=>x > y);
    }
    
    public void Test_2(){
       int a=3;
       int b=6;
       Check(a,b, (x,y)=> x != y);
    }
    
    void Main()
    {
    	Test_1();
    	Test_2();
    }
