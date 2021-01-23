    static void Shuffle(List<Node> nodes)
    {
        // Fisher-Yates shuffle.
        Random rng = new Random();
        for (int n = nodes.Count; n > 1; )
        {
            int k = rng.Next(n);
            --n;
            Swap(nodes[n], nodes[k]);
        }
    }
    static void Swap(Node a, Node b)
    {
        byte tempSymbol = a.Symbol;
        a.Symbol = b.Symbol;
        b.Symbol = tempSymbol;
        int tempFrequency = a.Frequency;
        a.Frequency = b.Frequency;
        b.Frequency = tempFrequency;
    }
