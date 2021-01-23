    var lines = File.ReadLines("C\\file");
    using (var iterator = new BufferedIterator<string>(lines))
    {
        int[] input = { 100, 50, 377 };
        for(int i = 0; i < input.Length; i++)
            output += iterator.GetItemAt(input[i]);
    }
