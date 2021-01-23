    string valueX = "assdf";
    string valueY = "assdf";
    
    if (valueX.Length == valueY.Length)
    {
        Console.WriteLine("Ok, Array is same lenght ... lets check the content");
    
        for (int i = 0; i < valueX.Length; i++)
        {
            if (valueX[i] != valueY[i])
            {
                Console.WriteLine("Not the same array!");
            }
        }
    }
    else
    {
        Console.WriteLine("Array is not equal in lenght");
    }
