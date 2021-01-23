	public static Func<string, dynamic> Pair(int x, Func<string, dynamic> y)
	{
		Func<string, dynamic> pair =
			   (a) =>
			   {
				   if (a == "con") return x;
				   if (a == "crd") return y;
				   throw new Exception();
			   };
		return pair;
	}
       
	public static void Print(Func<string, dynamic> pair)
	{
		while (true)
		{
			var next = pair("crd");
			Console.WriteLine((next == null ? "-":"+") +"> " + pair("con"));
			if (next != null)
			{
				Console.WriteLine("|");
				pair = (x) => next(x);
				continue;
			}
			break;
		}
	}
