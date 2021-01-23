    public class Program
    {
        public static void Main(string[] args)
        {
            //existing weights
            var existingWeights = new[] {
                new PercentileWeight(90, false, 95, true) { VotingWeightId = Guid.NewGuid() },
                new PercentileWeight(50, true, 60, false) { VotingWeightId = Guid.NewGuid() }
            };
            //get entire range with gaps filled in from 0 (non inclusive) to 100 (inclusive)
            var entireRange = existingWeights.CoveringRange(new PercentileWeight(0, false, 100, true)).ToList();
        }
    }
