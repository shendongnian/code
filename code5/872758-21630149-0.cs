    public static class WordsHelper
    {
        public static List<string> GetWordsInsideParenthesis(string s)
        {
            List<int> StartIndices = new List<int>();
            var rtn = new List<string>();
            var numOfOpen = s.Where(m => m == '(').ToList().Count;
            var numOfClose = s.Where(m => m == ')').ToList().Count;
            if (numOfClose == numOfOpen)
            {
                for (int i = 0; i < numOfOpen; i++)
                {
                    int ss = 0, sss = 0;
                    if (StartIndices.Count == 0)
                    {
                        ss = s.IndexOf('(') + 1; StartIndices.Add(ss);
                        sss = s.IndexOf(')');
                    }
                    else
                    {
                        ss = s.IndexOf('(', StartIndices.Last()) + 1;
                        sss = s.IndexOf(')', ss);
                    }
                    var words = s.Substring(ss, sss - ss).Split(' ');
                    foreach (string ssss in words)
                    {
                        rtn.Add(ssss);
                    }
                }
            }
            return rtn;
        }
    }
