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
        public static IEnumerable<Options> GetSetHighFlags(this Options opt)
        {
            var highFlags = GetHighFlags(opt);
            if (highFlags != 0)
            {
                for (ulong cFlag = 1; cFlag != 0; cFlag <<= 1)
                {
                    if ((highFlags & cFlag) != 0)
                    {
                        yield return (Options)cFlag;
                    }
                }
            }
        }
    }
