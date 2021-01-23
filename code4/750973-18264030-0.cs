    string grid = @"34 34 34 34
                34 34 34 34
                34 34 34 34
                34 34 34 34";
    var myArray = grid
        .Split(new char[] { '\n', '\r' })
        .Select(t => t.Split(new char[] { ' ', '\t' })
                        .Where((t1) =>
                        {
                            int i = 0;
                            return int.TryParse(t1, out i);
                        })
                        .Select(int.Parse).ToArray()
                ).ToArray();
