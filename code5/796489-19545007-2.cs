        static public string MatchKey(string input)
        {
           string strRegex = @"(__u__)(.+?:\s*)""(.*)""(,|})*";
            Regex myRegex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            IQS_Encryption.Encryption enc = new Encryption();
            int count = 1;
            string addedJson = "";
            int matchCount = 0;
            foreach (Match myMatch in myRegex.Matches(input))
            {
                if (myMatch.Success)
                {
                    //Console.WriteLine("REGEX MYMATCH: " + myMatch.Value);
                    input = input.Replace(myMatch.Value, "__e__" + myMatch.Groups[2].Value + "\"c" +  count + "\"" + myMatch.Groups[4].Value);
                    addedJson += "c"+count + "{" +enc.EncryptString(myMatch.Groups[3].Value, Encoding.UTF8.GetBytes("12345678912365478912365478965412"))+"},";
                }
                count++;
                matchCount++;
            }
            Console.WriteLine("MAC" + matchCount);
            return input + addedJson;
        }`
