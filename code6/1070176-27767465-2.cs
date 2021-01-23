	var demo = new Demo();
	Action<Object, String> handlerString = (s, e) =>  { Console.WriteLine("echo string {0}", e); };
	Action<Object, Int32> handlerInt = (s, e) =>  { Console.WriteLine("echo int {0}", e); };
	
	demo.StringEvent += handlerString.Once();
	demo.IntEvent += handlerInt.Once();
	demo.StringEvent += (s, e) => Console.WriteLine("i = {0}", e); 
	demo.NotifyOnWork();
