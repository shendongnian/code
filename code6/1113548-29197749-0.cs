    StringBuilder s = new StringBuilder();
                char[] t = txtString.ToArray();
                int i = 0;
                foreach (char c in t)
                {
                    s.Append(c);
                    if (i > 4 && c == ' ')
                    {
                        s.Append("\n");
                        i = 0;
                    }
                    i++;
                }
    return s.ToString();
