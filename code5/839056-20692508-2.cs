    public class TeamGroup
    {
        public string Group { get; set; }
        public string[] Teams { get; set; }
        public static TeamGroup ParseOut(string fullString)
        {
            TeamGroup tg = new TeamGroup{ Teams = new string[]{ } };
            int index = fullString.IndexOf("group = '");
            if (index >= 0)
            {
                index += "group = '".Length;
                int endIndex = fullString.IndexOf("'", index);
                if (endIndex >= 0)
                {
                    tg.Group = fullString.Substring(index, endIndex - index).Trim(' ', '\'');
                    endIndex += 1;
                    index = fullString.IndexOf(" and (team in (", endIndex);
                    if (index >= 0)
                    {
                        index += " and (team in (".Length;
                        endIndex = fullString.IndexOf(")", index);
                        if (endIndex >= 0)
                        {
                            string allTeamsString = fullString.Substring(index, endIndex - index);
                            tg.Teams = allTeamsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(t => t.Trim(' ', '\''))
                                .ToArray();
                        }
                    }
                }
            }
            return tg;
        }
    }
