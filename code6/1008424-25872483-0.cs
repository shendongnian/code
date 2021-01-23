    public TimeSpan FromPhpDateInterval(string phpDateInterval)
    {
        // Method to parse php's interval_spec (An interval specification)
        // The format starts with the letter P, for "period." Each duration period is represented by an integer value followed by a period designator. If the duration
        // contains time elements, that portion of the specification is preceded by the letter T. Here are some simple examples. Two days is P2D. Two seconds is PT2S.
        // Six years and five minutes is P6YT5M. See: http://php.net/manual/en/dateinterval.construct.php.
        DateTime now, then; now = then = DateTime.UtcNow;
        Regex regex = new Regex(@"\d+[A-Z]");
            
        string p = null;
        string t = null;
        if (phpDateInterval.StartsWith("P") && phpDateInterval.Contains("T"))
        {
            string[] split = phpDateInterval.Split('T');
            p = split[0].Substring(1);
            t = split[1];
        }
        else if (phpDateInterval.StartsWith("T"))
        {
             t = phpDateInterval.Substring(1);
        }
        else if (phpDateInterval.StartsWith("P"))
        {
            p = phpDateInterval.Substring(1);
        }
        else throw new Exception("Invalid interval_spec string format");
        if (!string.IsNullOrEmpty(p))
        {
            MatchCollection matches = regex.Matches(p);
            for (int i = 0; i < matches.Count; i++ )
            {
                string val = matches[i].Value;
                switch (val[val.Length - 1])
                {
                    case 'Y': // Years
                        then = then.AddYears(int.Parse(val.TrimEnd('Y')));
                        break;
                    case 'M': // Months
                        then = then.AddMonths(int.Parse(val.TrimEnd('M')));
                        break;
                    case 'D': // Days
                        then = then.AddDays(int.Parse(val.TrimEnd('D')));
                        break;
                    case 'W': // Weeks. These get converted into days, so can not be combined with D in php (makes no difference to us).
                        then = then.AddDays(int.Parse(val.TrimEnd('W')) * 7);
                        break;
                }
            }
        }
        if (!string.IsNullOrEmpty(t))
        {
            MatchCollection matches = regex.Matches(t);
            for (int i = 0; i < matches.Count; i++)
            {
                string val = matches[i].Value;
                switch (val[val.Length - 1])
                {
                    case 'H': // Hours
                        then = then.AddHours(int.Parse(val.TrimEnd('H')));
                        break;
                    case 'M': // Minutes
                        then = then.AddMinutes(int.Parse(val.TrimEnd('M')));
                        break;
                    case 'S': // Seconds
                        then = then.AddSeconds(int.Parse(val.TrimEnd('S')));
                        break;
                }
            }
        }
        return then.Subtract(now);
    }
