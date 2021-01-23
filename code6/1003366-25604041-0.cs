	int age = 25;
	Action<string> withClosure = s => Console.WriteLine("My name is {0} and I am {1} years old", s, age);
	Action<string> withoutClosure = s => Console.WriteLine("My name is {0}", s);
	Console.WriteLine(withClosure.Method.IsStatic);
	Console.WriteLine(withoutClosure.Method.IsStatic);
