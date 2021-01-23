    private static List<int> AllPossibleCombinations(IList<int> alphabet)
    {
        List<int[]> combinations = new List<int[]>();
        MakeCombination(combinations, alphabet.Count, new int[0]); // Start recursion
        combinations.RemoveAt(0);   // Remove empty combination
        return combinations.ConvertAll(c => c.Aggregate(0, (sum, index) => sum * 10 + alphabet[index]));
    }
    private static void MakeCombination(List<int[]> output, int length, int[] usedIndices)
    {
        output.Add(usedIndices);
        for (int i = 0; i < length; i++)
            if (Array.IndexOf(usedIndices, i) == -1)    // If the index wasn't used earlier
            {
                // Add element to the array of indices by creating a new one:
                int[] indices = new int[usedIndices.Length + 1];
                usedIndices.CopyTo(indices, 0);
                indices[usedIndices.Length] = i;
                if (length + 1 != indices.Length)
                    MakeCombination(output, length, indices);  // Recursion
            }
    }
