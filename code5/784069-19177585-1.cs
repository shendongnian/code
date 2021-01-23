    List<string> Data = File.ReadAllLines(filename);
    string[] coordLine = Data[0].Split(' ');
    Grid viewGrid = new Grid(Coordinates(int.Parse(coordLine [0]), int.Parse(coordLine [1]));
    for (int i = 1; i < Data.Count / 2; i++)
    {
        string[] line1 = Data[2 * i - 1].Split(' ');
        string line2 = Data[2 * i];
        viewGrid.AddToCollection(new Rov(Int32.Parse(line1[0]), Int32.Parse(line1[1]), line1[2], line2));
    }
