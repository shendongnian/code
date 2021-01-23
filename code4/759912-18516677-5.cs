    public static double MyFunc(double x, double y, double z)
    {
    	return x + y + z;
    }
    _functions = new Dictionary<string, Delegate> ();
    AddFunction(MyFunc);
    Console.WriteLine(_functions["MyFunc"].DynamicInvoke(1, 2.5, 0));//3.5
