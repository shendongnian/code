    public abstract class Stats<T>
    {
        public abstract T Something { get; }
    }
    public class PlayerMatchStats : Stats<int?>
    {
        public override int? Something { get { return 0; } }
    }
    Stats<int?> stats = new PlayerMatchStats();
