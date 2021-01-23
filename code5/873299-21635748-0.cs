    class ProgramOption
    {
        //...
        public ProgramOptions(string s = null)
        {
            //...
        }
        //...
        public static implicit operator ProgramOptions(string s)
        {
            return new ProgramOptions(s);
        }
    }
