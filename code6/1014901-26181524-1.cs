    public class CappedCostSubstitutionEnumerator<T>
    {
        private static Dictionary<string, List<Sequence<T>>> Cache { get; set; }
        static CappedCostSubstitutionEnumerator()
        {
            Cache = new Dictionary<string, List<Sequence<T>>>();
        }
        public double AuthorizedCost { get; set; }
        public List<Substitution<T>> Substitutions { get; set; }
        
        public CappedCostSubstitutionEnumerator(double maxAuthorizedCost)
        {
            Substitutions = new List<Substitution<T>>();
            AuthorizedCost = maxAuthorizedCost;
        }
        
        public List<List<T>> EnumerateSequenceSubstitutions(List<T> sequence)
        {
            var values = EnumerateSequenceSubstitutions(new Sequence<T>(sequence));
            return values.Select(s => s as List<T>).ToList();
        }
        private List<Sequence<T>> EnumerateSequenceSubstitutions(Sequence<T> sourceSequence)
        {
            var sourceSequenceKey = sourceSequence.ToString();
            if (Cache.ContainsKey(sourceSequenceKey))
            {
                return Cache[sourceSequenceKey];
            }
            else
            {
                var sequenceSubstitutionsResults = new List<Sequence<T>> { sourceSequence };
                foreach (var substitution in Substitutions.Where(substitution => substitution.Cost <= AuthorizedCost))
                {
                    SubstituteWhereOriginalSubstitutionSequenceIsFound(sourceSequence, substitution, sequenceSubstitutionsResults);
                }
                Cache.Add(sourceSequenceKey, sequenceSubstitutionsResults);
                return sequenceSubstitutionsResults;
            }
        }
        private void SubstituteWhereOriginalSubstitutionSequenceIsFound(Sequence<T> sourceSequence, Substitution<T> substitution,
            List<Sequence<T>> sequenceSubstitutionsResults)
        {
            var indexInSequence = 0;
            var originalSequenceLength = substitution.OriginalSequence.Count();
            var upperIndexInSequence = sourceSequence.Count() - originalSequenceLength;
            // we are going to look for the substitution pattern at each possible place in the source sequence
            while (indexInSequence <= upperIndexInSequence)
            {
                var evaluatedMatch = sourceSequence.Skip(indexInSequence).Take(originalSequenceLength);
                if (evaluatedMatch.SequenceEqual<T>(substitution.OriginalSequence))
                {
                    var start = sourceSequence.Take(indexInSequence);
                    var substituted = substitution.SwappedSequence;
                    var remain = sourceSequence.Skip(indexInSequence + originalSequenceLength);
                    // now we want the subsequences without taking cost into account
                    var subSequences = EnumerateSequenceSubstitutions(new Sequence<T>(remain));
                    // we filter the subsequences on the total cost here
                    foreach (
                        var subSequence in
                            subSequences.Where(
                                subSeq => (subSeq.Cost + substitution.Cost) <= (AuthorizedCost - sourceSequence.Cost)))
                    {
                        sequenceSubstitutionsResults.Add(
                            new Sequence<T>(start.Concat(substituted).Concat(subSequence))
                            {
                                Cost = substitution.Cost + subSequence.Cost
                            });
                    }
                }
                indexInSequence++;
            }
        }
    }
