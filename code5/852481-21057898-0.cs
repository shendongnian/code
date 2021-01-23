    string value = "assdf";
    char[] X = value.ToCharArray();
    string valueY = "assdf";
    char[] Y = valueY.ToCharArray();
    
    if (X.Count() == Y.Count())
    {
        int arrayLenght = X.Count();
        Console.WriteLine("Ok, Array is same lenght ... lets check the content");
    
        for (int i = 0; i < arrayLenght; i++)
        {
            if (X[i] != Y[i])
            {
                Console.WriteLine("Not the same array!");
            }
        }
    }
    else
    {
        Console.WriteLine("Array is not equal");
    }
    
    Console.ReadKey();
