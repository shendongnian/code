    public class PlayerInfo
    {
        public virtual string Name { get; set; }
        public virtual int Score { get; set; }
    }
    public class PlayerInfoDetection : PlayerInfo
    {
        public int Revision { get; private set; }
        public override string Name
        {
            set
            {
                base.Name = value;
                Revision++;
            }
        }
        public override int Score
        {
            set
            {
                base.Score = value;
                Revision++;
            }
        }
    }
    private static void Example()
    {
        PlayerInfo pi = new PlayerInfoDetection();
        Console.WriteLine(((PlayerInfoDetection)pi).Revision);
        pi.Name = "weston";
        Console.WriteLine(((PlayerInfoDetection)pi).Revision);
        pi.Score = 123;
        Console.WriteLine(((PlayerInfoDetection)pi).Revision);
    }
