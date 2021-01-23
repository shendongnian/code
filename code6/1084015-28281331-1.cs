      private string DecodeConfig(StringBuilder OptionsBuilder)
        {
            string result = String.Empty;
            string Options = OptionsBuilder.ToString();
            if (!string.IsNullOrEmpty(Options) && Options.Contains(Consts.AMPERSAND))
            {
                string[] entries = Options.Split(Consts.AMPERSAND);
                StringBuilder chars = new StringBuilder(Consts.OUTPUT_MAX_SIZE);
                for (int i = 0; i < entries.Length; i++)
                {
                    int resultParse;
                    if (int.TryParse(entries[i], out resultParse))
                    {
                        chars.Append((char)resultParse);
                    }
                }
                result = chars.ToString();
            }
            return result;
        }
