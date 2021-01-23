    static void PrintContSubArrays(char[] arr)
    {
        Console.WriteLine(String.Join(Environment.NewLine,
				from n1 in Enumerable.Range(0, arr.Length)
				select String.Join(" ",
					from n2 in Enumerable.Range(1, arr.Length - n1)
					select String.Format("({0})", String.Join(" ", arr.Skip(n1).Take(n2))))));
        Console.ReadLine();
    }
