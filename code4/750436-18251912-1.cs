    private int GetInt(string s)
    {
            int posStart, posEnd;
            bool isNumber;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    if (isNumber)
                    {
                        posEnd = i;
                    }
                    else
                    {
                        posStart = i;
                    }
                }
                else if(isNumber)
                {
                    break;
                }
            }
        return int.Parse(s.Substring(posStart, posEnd));
    }
