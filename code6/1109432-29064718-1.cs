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
        
        public Irc GetResultByRegex()
        {
            Irc irc = new Irc();
            MatchMaxTargets(ref irc.maxTargets);
            MatchWallChops(ref irc.wallChops);
            MatchChanTypes(ref irc.chanTypes);
            return irc;
        }
        private void MatchMaxTargets(ref int maxTargets)
        {
            Regex regex = new Regex(@"(?<=MAXTARGETS=)(\d+)");
            Match m = regex.Match(input);
            if (m.Success){
                maxTargets = Convert.ToInt32(m.Groups[1].Value);
            }
        }
        private void MatchWallChops(ref bool wallChops)
        {
            if (Regex.IsMatch(input, "WALLCHOPS"))
            {
                wallChops = true;
            }
        }
        private void MatchChanTypes(ref string chanTypes)
        {
            Regex regex = new Regex(@"(?<=CHANTYPES=)(.*?)(?=\s)");
            Match m = regex.Match(input);
            if (m.Success)
            {
                chanTypes = m.Groups[1].Value;
            }
        }
      
    }
    class Irc
    {
        public int maxTargets;
        public bool wallChops;
        public string chanTypes;
    }
