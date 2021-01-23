        public static void Main()
        {
            var results = new List<Result>
                              {
                                  new Result {DeviceId = 1, ActionType = 1},
                                  new Result {DeviceId = 1, ActionType = 2},
                                  new Result {DeviceId = 1, ActionType = 3},
                                  new Result {DeviceId = 2, ActionType = 1},
                                  new Result {DeviceId = 3, ActionType = 1},
                                  new Result {DeviceId = 4, ActionType = 1},
                                  new Result {DeviceId = 5, ActionType = 1},
                                  new Result {DeviceId = 6, ActionType = 1},
                                  new Result {DeviceId = 6, ActionType = 2},
                              };
            List<Result> result = results
                .GroupBy(x => x.DeviceId)
                .Where(x => x.Count() == 1)
                .SelectMany(x => x)
                .Distinct()
                .ToList();
            result.ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    public sealed class Result : IEqualityComparer<Result>
    {
        public int DeviceId { get; set; }
        public int ActionType { get; set; }
        public bool Equals(Result x, Result y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.DeviceId == y.DeviceId && x.ActionType == y.ActionType;
        }
        public int GetHashCode(Result obj)
        {
            unchecked
            {
                return (obj.DeviceId*397) ^ obj.ActionType;
            }
        }
        public override string ToString()
        {
            return string.Format("DeviceId: {0}, ActionType: {1}", DeviceId, ActionType);
        }
    }
