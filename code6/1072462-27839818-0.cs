    [TestClass]
    public class PLinqTests
    {
        private static readonly Stopwatch Watch = Stopwatch.StartNew();
        [TestMethod]
        public async Task TestPerformAsync()
        {
            await PerformActionAsync(Enumerable.Range(0, 10));
        }
        private Task PerformActionAsync(IEnumerable<int> xIds)
        {
            return Task.Run(() =>
            {
                var affectedYIds = xIds
                    .AsParallel()
                    .WithDegreeOfParallelism(5)
                    .SelectMany(this.GetAffectedYIdsLongRunning)
                    .Distinct();
                affectedYIds.ForAll(this.ExcuteLongRunningAction);
            });
        }
        private void ExcuteLongRunningAction(int yId)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Executed {0} at {1}.", yId, Watch.Elapsed.Seconds);
        }
        private IEnumerable<int> GetAffectedYIdsLongRunning(int xId)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Getting Affected for {0} at {1}.", xId, Watch.Elapsed.Seconds);
            return Enumerable.Range(30, 10);
        }
    }
