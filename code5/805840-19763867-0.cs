    void Main()
    {
    	string strRegex = @"^\+.+\s";
            RegexOptions myRegexOptions = RegexOptions.Multiline;
            Regex myRegex = new Regex(strRegex, myRegexOptions);
            string strTargetString = @"+CMGR: ""REC UNREAD"",""MSG"","""",""2013/11/04 13:52:18+28""" + "\r\n" + @"0E2A0E270E310E2A0E140E350E040E230E310E1A00200E220E340E190E140E350E150E490E2D0E190E230E310E1A0E040E230E310E1A0E170E380E010E460E040E197";
    
            foreach (Match myMatch in myRegex.Matches(strTargetString))
            {
                if (myMatch.Success)
                {
                   Console.WriteLine(myRegex.Split(strTargetString));
                }
            }
    }
