        public static void GetNumberOfCodeLines(string text, out int linesOfCode, out int totalLines)
        {
            linesOfCode = 0;
            totalLines = 0;
            if (string.IsNullOrWhiteSpace(text))
            {
                // there is no code in this text
                return;
            }
            string[] lines = null;
            // test for windows like system new line
            if (text.IndexOf("\r\n") > -1)
            {
                lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            } // test for unix like systems new line
            else if (text.IndexOf('\n') > -1)
            {
                lines = text.Split(new char[] { '\n' }, StringSplitOptions.None);
            }
            else
            {
                // it's just 1 line of code
                linesOfCode = 1;
                totalLines = 1;
                return;
            }
            foreach(string line in lines)
            {
                totalLines++;
                string lineTest = line.Trim(new char[] { ' ', '\t' });
                if (lineTest.Length > 0 && !lineTest.StartsWith("//") && lineTest != "{" && lineTest != "}" )
                {
                    linesOfCode++;
                }
            }
        }
