    using System;
    using Newtonsoft.Json;
    ...
    static void Main(string[] args)
	{
		var c = new C<string>() { Prop0 = "zero", Prop2 = "two" };
		var json = JsonConvert.SerializeObject(c);
		var prop2 = GetProp2(json);
		Console.WriteLine("prop2 from C: " + (prop2 ?? "null"));
		var b = new B() { Prop0 = "zero", Prop1 = "one" };
		json = JsonConvert.SerializeObject(b);
		prop2 = GetProp2(json);
		Console.WriteLine("prop2 from B: " + (prop2 ?? "null"));
		Console.Write("Press any key to exit...");
		Console.ReadKey();
    }
	static object GetProp2(string json)
	{
		A a = JsonConvert.DeserializeObject<C<string>>(json);
		var prop2 = a is C<string> ? (a as C<string>).Prop2 : null;
		return prop2;
	}
