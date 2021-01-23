    public abstract class Stats<T> where T : struct
    {
        // instead of the following with T being int?
        // public abstract T Something { get; }
        // have the following with T being int
        public abstract T? Something { get; }
    }
    public class PlayerMatchStats : Stats<int> { ... }
    // this is now valid:
    Stats<int> stats = new PlayerMatchStats(); // PlayerMatchStats inherits Stats
