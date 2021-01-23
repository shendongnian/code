    public static class OptionsHelper
    {
        private readonly static Options HighFlags = Options.FlagM 
            | Options.FlagN
            // ...
            | Options.FlagZ;
    
        public static bool HasHighFlags(this Options opt)
        {
            return (opt & HighFlags) != 0;
        }
        public static Options GetHighFlags(this Options opt)
        {
            return (opt & HighFlags);
        }
    }
