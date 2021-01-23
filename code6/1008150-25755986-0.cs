    IEnumerable<int> r = new [] {1, 2, 3, 4};
    int prevline = -1;
    foreach (var line in r) {
        if (prevline == 2)
            Console.WriteLine("==> ", n);
        else Console.WriteLine(line);
    }
