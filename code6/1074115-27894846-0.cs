    List<Task<float>> tasks = new List<Task<float>>();
    for (float i = -3.0f; i < 3.0f; i+= 1.0f)
    {
        float input = i;
        Console.WriteLine("sent " + i);
        Task<float> task = Task.Factory.StartNew<float>(() => Div(5.0f, input));
        tasks.Add(task);
    }
