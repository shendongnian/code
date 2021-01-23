        static Dictionary<char, int> cyper = new Dictionary<char, int>
    {
	{'A', 44},
	{'B', 45},
	{'C', 46},
	{'D', 47},
	{'E', 48},
	{'F', 49},
    // .. etc
    };
// ... 
            Console.WriteLine(string.Format("{0:X}", cyper['A'])); // will print 2C
