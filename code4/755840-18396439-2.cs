     for (int i = 0; i < s.Length; i += length)
        {
            int index=s.IndexOf(" ",i, s.Length-i)
    
            if (index!=-1 && index + length <= s.Length)
            {
                i =index;           
                yield return s.Substring(index, length);
            }
            else
            {
                index= s.LastIndexOf(" ", 0, i);
                if(index==-1)
                    yield return s.Substring(i);
                else
                {
                    i = index;
                    yield return s.Substring(i);
                }
            }
        }
