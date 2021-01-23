    public static class PercentileWeightExtension
    {
        public const decimal Delta = 0.00000000000000000000000001M;
        public static IEnumerable<PercentileWeight> CoveringRange(this IEnumerable<PercentileWeight> inputs, PercentileWeight coveringRange)
        {
            //todo: following code expects no overlaps check that none exist
            //create lower and upper weights from coveringRange
            var lower = new PercentileWeight(decimal.MinValue, true, coveringRange.LowerBoundPercentageRanking, !coveringRange.LowerBoundInclusive);
            var upper = new PercentileWeight(coveringRange.UpperBoundPercentageRanking, !coveringRange.UpperBoundInclusive, decimal.MaxValue, true);
            //union new lower and upper weights with incoming list and order to process
            var orderedInputs = inputs.Union(new [] { lower, upper })
                .OrderBy(item => item.LowerBoundPercentageRanking)
                .ToList();
            //process list in order filling in the gaps
            for (var i = 1; i < orderedInputs.Count; i++)
            {
                var gap = GetPercentileWeightBetweenLowerAndUpper(orderedInputs[i - 1], orderedInputs[i]);
                if (gap != null)
                {
                    yield return gap;
                }
                //dont want to output last input this represents the fake upper made above and wasnt in the original input
                if (i < (orderedInputs.Count - 1))
                {
                    yield return orderedInputs[i];    
                }
            }
        }
        private static PercentileWeight GetPercentileWeightBetweenLowerAndUpper(PercentileWeight lowerWeight, PercentileWeight upperWeight)
        {
            var lower = lowerWeight.UpperBoundPercentageRanking;
            var lowerInclusive = lowerWeight.UpperBoundInclusive;
            var upper = upperWeight.LowerBoundPercentageRanking;
            var upperInclusive = upperWeight.LowerBoundInclusive;
            //see if there is a gap between lower and upper (offset by a small delta for non inclusive ranges)
            var diff = (upper + (upperInclusive ? 0 : Delta)) - (lower - (lowerInclusive ? 0 : Delta));
            if (diff > Delta)
            {
                //there was a gap so return a new weight to fill it
                return new PercentileWeight
                {
                    LowerBoundPercentageRanking = lower,
                    LowerBoundInclusive = !lowerInclusive,
                    UpperBoundPercentageRanking = upper,
                    UpperBoundInclusive = !upperInclusive
                };
            }
            return null;
        }
    }
