    using System;
    using System.Collections.Generic;
    class Program
    {
        static List<T> GetInitializedList<T>(T value, int count)
            {
	        // This generic method returns a List with ten elements initialized.
	        // ... It uses a type parameter.
	        // ... It uses the "open type" T.
	        List<T> list = new List<T>();
	        for (int i = 0; i < count; i++)
	        {
	            list.Add(value);
	        }
	        return list;
            }
        static void Main()
            {
	        // Use the generic method.
	        // ... Specifying the type parameter is optional here.
	        // ... Then print the results.
	        List<bool> list1 = GetInitializedList(true, 5);
	        List<string> list2 = GetInitializedList<string>("Perls", 3);
	        foreach (bool value in list1)
	        {
	            Console.WriteLine(value);
	        }
	        foreach (string value in list2)
	        {
	            Console.WriteLine(value);
	        }
            }
        }
