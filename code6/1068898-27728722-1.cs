    string input = "S#####\n.....#\n#.####\n#.####\n...#.G\n##...#";
    char[,] charArray = new char[6, 6];
    var lines = input.Split(new [] { '\n' });
    int row = 0;
    foreach (string line in lines)
    {
        int column = 0;
        foreach (char character in line)
        {
           charArray[row, column] = character;
           column++;
        }
        row++;
    }
    Console.ReadKey();
