    using(FileStream fs = new FileStream("Test.txt", FileMode.Create))
    using(StreamWriter sw = new StreamWriter(fs))
    {
        Console.SetOut(sw);       
        for (int i = 0; i < N; i++)
        {            
            Console.WriteLine(position[i] + " ");
        }
        sum++; // instead of sum += 1
    } // stream will be closed automatically
