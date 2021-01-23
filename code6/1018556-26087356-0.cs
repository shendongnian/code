    for (int i = 0; i < stringArray.Length; i++)
    {
        if (i == pointerLocation)
        {
            Console.WriteLine("> " + stringArray[pointerLocation]);
        }
        else
        {
            Console.WriteLine(stringArray[pointerLocation]);
        }
    }
