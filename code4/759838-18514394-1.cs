    void Main()
    {
	   DoSomething();
	   DoIf(true, DoWork1);
	   DoIf(false, DoWork2);
       var MyFunctions = new List<MyFunction>() { DoWork1, DoWork2 };
	
	   foreach(var func in MyFunctions) {
		   DoIf(someBoolCondition == 0, func);
	   }
    }
    public delegate void MyFunction();
    void DoSomething() {
	   Console.WriteLine("Always");
    }
    public void DoWork1() {
        Console.WriteLine("Only if it was true");
    }
    public void DoWork2() {
	   Console.WriteLine("Only if it was true");
    }
    void DoIf(bool condition, MyFunction function) {
	   if(condition) {
	   	   function();
	   }
    }
