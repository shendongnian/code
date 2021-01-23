    for (int i = 0; i < Apples.Length; i++)  //this is the only thing i'm having trouble with
    {
        for (int j = 0; j < Apples[i].LongLength; j++)
        {
            System.Console.WriteLine("Element[{0}][{1}]: ", i, j);
            System.Console.Write(Apples[i][j].ToString());
            System.Console.Write("\n\r");
        }
    }
