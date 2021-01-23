        string sortString(string s)
        {
            string newString = s;
            for (int p = 0; p < s.Length; p++)
            {
                for (int i = p; i < s.Length; i++)
                {
                    if (s[p] > s[i])
                    {
                        newString = "";
                        for (int j = 0; j < s.Length; j++)
                        {
                            if (j == i)
                            {
                                newString += s[p];
                            }
                            else
                                if (j == p)
                                {
                                    newString += s[i];
                                }
                                else
                                {
                                    newString += s[j];
                                }
                        }
                        s = newString;
                    }
                }
            }
            return newString;
        }
