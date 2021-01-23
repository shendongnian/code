    public class PlayerInfo
    {
        public int Revision { get; private set; }
        public string Name { get; [IncreaseRevision] set; }
        public int Score { get; [IncreaseRevision] set; }
    }
