            String pattern = @"Create(\s+)Table(\s+)(\([a-z0-9]+\))(\s+)Columns(\s+)(((\([a-z0-9;]+\))\s*)+)";
            Match CMD = Regex.Match(Command, pattern, RegexOptions.IgnoreCase);
            if (CMD.Success)
            {
                String SubCommand = CMD.Groups[6].Value;
                String SubPattern = @"\(([a-z0-9]+);(INTEGER|DECIMAL|STRING);(\d{1,3});(YES|NO);(YES|NO);(YES|NO);([a-z0-9]+)\)";
                MatchCollection match = Regex.Matches(SubCommand, SubPattern, RegexOptions.IgnoreCase);
               if (match.Count != 0)
                {
                    return true;
                }
            }
