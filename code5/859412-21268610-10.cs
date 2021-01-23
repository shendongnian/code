    var values = Enumerable.Range(1, 5).ToDictionary(n => n, n => new List<int>());
    bool firstIteration = true;
    var visited = new BitArray(5, false);
    foreach(var sample in selected)
    {
        int number = Int32.Parse(sample.proj.Last().ToString());
        visited[number - 1] = true;
        if (number == 1 && !firstIteration)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!visited[i])
                    values[i + 1].Add(0);
            }
            visited.SetAll(false);
        }
        values[number].Add(sample.WDC);
        firstIteration = false;
    }
