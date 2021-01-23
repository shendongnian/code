    class ProgramOption
    {
        //...
        public ProgramOptions(string str = null)
        {
            //...
            if (!string.IsNullOrWhiteSpace(str))
            {
                /* store or parse str */
                //...
            }
        }
        //...
        public static implicit operator ProgramOptions(string str)
        {
            return new ProgramOptions(str);
        }
    }
