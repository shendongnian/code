            string testAnswer = "7 7+9700 700 007 400 -7 8";
            bool valid = true;
            string retVal = "";
            Regex answerRegex = new Regex(@"(\s+|^)(?<!-)[1-9][0-9,]*(\s+|$)");
            if (testAnswer.Contains(","))
            {
                testAnswer = testAnswer.Replace(",", "");
                retVal = testAnswer;
            }
            MatchCollection answerMatch = answerRegex.Matches(testAnswer.Trim());
            if (testAnswer == String.Empty || answerMatch.Count <= 0)
            {
                valid = false;
                retVal = "error";
            }           
            else
            {
                retVal = "comp";
                foreach(Match m in answerMatch) {
                    Console.WriteLine(m.Groups[0].Value);
                }
            }
