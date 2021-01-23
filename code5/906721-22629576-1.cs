    static void Shuffle(List<Node> allNodes)
    {
        // Fisher-Yates shuffle.
        Random rng = new Random();
        for (int n = allNodes.Count; n > 1; )
        {
            int k = rng.Next(n);
            --n;
            // Swap the contents of the node [n] with node [k]
            byte tempSymbol = allNodes[n].Symbol;
            allNodes[n].Symbol = allNodes[k].Symbol;
            allNodes[k].Symbol = tempSymbol;
            int tempFrequency = allNodes[n].Frequency;
            allNodes[n].Frequency = allNodes[k].Frequency;
            allNodes[k].Frequency = tempFrequency;
        }
    }
