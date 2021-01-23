            string input = "12/29/2014 00:00 - 1/5/2015 00:00";
            Regex regex = new Regex(@"(?<month>(1[0-2]|1\d|\d))/(?<day>(3[0-1]|[0-2]\d|\d))/(?<year>[1-2]\d{3})\s(?<hour>(2[0-3]|[0-1]\d)):(?<min>[0-5]\d)");
            MatchCollection match = regex.Matches(input);
            foreach (Match m in match)
            {
           string year = m.Groups["year"].Value;
           string month = m.Groups["month"].Value;
           string day = m.Groups["day"].Value;
           string hour = m.Groups["hour"].Value;
           string min = m.Groups["min"].Value;
           Trace.WriteLine(m.Groups["year"].Value);
           Trace.WriteLine(m.Groups["month"].Value);
           Trace.WriteLine(m.Groups["day"].Value);
           Trace.WriteLine(m.Groups["hour"].Value);
           Trace.WriteLine(m.Groups["min"].Value);
            }
