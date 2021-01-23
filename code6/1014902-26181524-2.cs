    private static void Main(string[] args)
    {
        var p = new CappedCostSubstitutionEnumerator<int>(0.5);
        p.Substitutions.Add(new Substitution<int>() {OriginalSequence = new int[] {1}, SwappedSequence = new int[] {3}, Cost = 0.2});
        p.Substitutions.Add(new Substitution<int>() { OriginalSequence = new int[] { 2,3,4 }, SwappedSequence = new int[] { 4,3 }, Cost = 0.3 });
        p.Substitutions.Add(new Substitution<int>() { OriginalSequence = new int[] { 5 }, SwappedSequence = new int[] { 2 }, Cost = 0.4 });
        p.Substitutions.Add(new Substitution<int>() { OriginalSequence = new int[] { 5,1 }, SwappedSequence = new int[] { 4, 3 }, Cost = 0.3 });
        p.Substitutions.Add(new Substitution<int>() { OriginalSequence = new int[] { 2,3 }, SwappedSequence = new int[] { 4, 3 }, Cost = 0.3 });
        p.Substitutions.Add(new Substitution<int>() { OriginalSequence = new int[] { 2 }, SwappedSequence = new int[] { 4, 3 }, Cost = 0.1 });
        p.Substitutions.Add(new Substitution<int>() { OriginalSequence = new int[] {  4 }, SwappedSequence = new int[] { 4, 3 }, Cost = 0.3 });
        var results = p.EnumerateSequenceSubstitutions(new List<int>() { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 5 });
        // results contains 5390 values
    }
