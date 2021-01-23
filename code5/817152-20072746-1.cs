            string s = "1234567877y3434";
            for (int i = 5; i < s.Length; i += 5 + Environment.NewLine.Length)
            {
                s = s.Substring(0, i) + Environment.NewLine + s.Substring(i, s.Length - i);
            }
