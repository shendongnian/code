    static void OutputAllArrayIndices(Array arr)
    {
        var i = 0;
        foreach (int item in arr)
        {
            var coords = IndexToCoordinates(i++, arr);
            Console.WriteLine(string.Join(", ", coords));
        }
    }
