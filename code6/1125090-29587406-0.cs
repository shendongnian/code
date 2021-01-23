    public class RegexTelephoneNumber
    {
        public void Test()
        {
            Regex regex = new Regex(@"^\+\d{1,4}-[1-9]\d{0,9}$");
            Trace.Assert(MatchTest(regex, "+91234-1234567") == false);
            Trace.Assert(MatchTest(regex, "+9123-1234567") == true);
            Trace.Assert(MatchTest(regex, "+") == false);
            Trace.Assert(MatchTest(regex, "-") == false);
            Trace.Assert(MatchTest(regex, "91234545555") == false);
            Trace.Assert(MatchTest(regex, "+91-012345") == false);
            Trace.Assert(MatchTest(regex, "+91-12345678910") == false);
    
            Trace.Assert(MatchTest(regex, "++91234-1234567") == false);
            Trace.Assert(MatchTest(regex, "+91234-1234567+") == false);
            Trace.Assert(MatchTest(regex, "aa+91234-1234567+bb") == false);
            Trace.Assert(MatchTest(regex, "+91-12") == true);
        }
    
        private bool MatchTest(Regex regex, string text)
        {
            Match match = regex.Match(text);
            return match.Success;
        }
    }
