    static void Main(string[] args)
    {
        var hours = 13;
        for (var items = 16; items < 22; items++)
            PrintDistribution(items, hours);
    }
    private static void PrintDistribution(int items, int hours)
    {
        Console.WriteLine(string.Format("\nItems={0}, Hours={1}", items, hours));
        for (var i = 0; i < (items / hours) * hours; i++)
        {
            Console.Write('X');
            if ((i + 1) % hours == 0)
                Console.WriteLine();
        }
        var line = new StringBuilder(new string(' ', hours));
        var remaining = items % hours;
        var evens = remaining / 2;
        var odd = remaining - (evens * 2);
        var seq = BinaryTreeSequence(hours / 2).GetEnumerator();
        for (var i = 0; i < evens; i++)
        {
            seq.MoveNext();
            line[seq.Current] = 'X';
            line[hours - seq.Current - 1] = 'X';
        }
        if (odd > 0)
            if (hours % 2 == 0)
            {
                seq.MoveNext();
                line[seq.Current] = 'X';
            }
            else
                line[hours / 2] = 'X';
        Console.WriteLine(line);
    }
    public static IEnumerable<int> BinaryTreeSequence(int count)
    {
        if (count > 1)
            yield return count - 1; 
        if (count > 0)
            yield return 0;
        var seqQueue = new Queue<Tuple<int, int, int>>();
        Enqueue(seqQueue, 0, count - 1);
        for (var seqIndex = count - 2; seqIndex > 0; seqIndex--)
        {
            var moreNeeded = seqQueue.Count < seqIndex;
            var seq = seqQueue.Dequeue();
            yield return seq.Item1;
            if (moreNeeded)
            {
                Enqueue(seqQueue, seq.Item1, seq.Item3);
                Enqueue(seqQueue, seq.Item2, seq.Item1);
            }
        }
    }
    private static void Enqueue(Queue<Tuple<int, int, int>> q, int min, int max)
    {
        var midPoint = (min + max) / 2;
        if (midPoint != min && midPoint != max)
            q.Enqueue(Tuple.Create(midPoint, min, max));
    }
