    using(FileStream stream = new FileStream("Test.txt", FileMode.Create))
    using(StreamWriter writer = new StreamWriter(stream))
    {
        TextWriter standardOutput = Console.Out;
        for (int i = 0; i < N; i++)
        {
            Console.SetOut(standardOutput);       
            Console.WriteLine(position[i] + " ");
            Console.SetOut(writer);
            Console.WriteLine(position[i] + " ");
        }
        sum++; // instead of sum += 1
    } // stream will be closed automatically
