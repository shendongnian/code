    using(var writer = new StreamWriter("Cars.txt"))
    {
        for (int i = 0; i < 4; i++)
        {
            writer.Write(CarProps[i]); 
        }
    }
