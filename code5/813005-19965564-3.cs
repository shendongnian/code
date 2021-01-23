    static void Main(string[] args)
    {
        int items = 24, hours = 13;
        for (var i = 0; i < (items/hours)*hours; i++)
        {
            Console.Write('X');   
            if ((i+1) % hours == 0)
                Console.WriteLine();
        }
        var line = new StringBuilder(new string(' ', hours));
        var remaining = items % hours;
        var evens = remaining/2;
        var odd = remaining - (evens*2);
        var seq = BinaryTreeSequence((int) Math.Ceiling(hours/2.0)).ToArray();
        var count = 0;
        foreach (var i in seq)
        {
            if (count >= evens)
                break; 
            line[i] = 'X';
            line[hours -i - 1] = 'X';
            count++;
        }
        if (odd > 0)
            line[hours/2] = 'X';
        Console.WriteLine(line);
    }
    public static IEnumerable<int> BinaryTreeSequence(int count)
    {
        if (count > 0)
            yield return 0;
        var seqQueue = new Queue<Tuple<int, int, int>>();
        seqQueue.Enqueue(GetTuple(0, count - 1));
        for (var seqIndex = count - 2; seqIndex > 0; seqIndex--)
        {
            var moreNeeded = seqQueue.Count < seqIndex;
            var seq = seqQueue.Dequeue();
            yield return seq.Item1;
            if (moreNeeded)
            {
                seqQueue.Enqueue(GetTuple(seq.Item1, seq.Item3));
                seqQueue.Enqueue(GetTuple(seq.Item2, seq.Item1));
            }
        }
    }
    private static Tuple<int, int, int> GetTuple(int min, int max)
    {
        return Tuple.Create((int)(((long)min + max) / 2), min, max);
    }
