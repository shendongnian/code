    class IrcParser
    {
        private string input;
        public IrcParser(string input)
        {
            this.input = input;
        }
        public Irc GetResult()
        {
            Irc irc = new Irc();
            string[] result = input.Split();
            for (int i = 0; i < result.Length; i++)
			{
                string[] FieldValue = result[i].Split('=');
                switch (FieldValue[0])
                 {
                    case "MAXTARGETS":
                         irc.maxTargets = Convert.ToInt32(FieldValue[1]);
                         break;
                    case "WALLCHOPS":
                         irc.wallChops = true;
                         break;
                    case "CHANTYPES":
                        irc.chanTypes = FieldValue[1];
                        break;
                }
			}
            return irc;
        }       
    }
    class Irc
    {
        public int maxTargets;
        public bool wallChops;
        public string chanTypes;
    }
