            int maxLength = 0;
            string reStr = "";
            foreach (string s in replacements.Keys)
            {
                if (textBox2.Text.Contains(s))
                {
                    if (maxLength < s.Length)
                    {
                        maxLength = s.Length;
                        reStr = s;
                    }
                }
            }
            if (reStr != "")
                textBox2.Text = textBox2.Text.Replace(reStr, replacements[reStr]);
