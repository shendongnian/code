     for (int i = 0; i < s.Length; i += length)
        {
            int index=s.IndexOf(" ",i, s.Length-i)
    
            if (index!=-1 && index + length <= s.Length)
            {
                i+=index - length;           
                yield return s.Substring(index, length);
            }
            else
            {
                yield return s.Substring(i);
            }
        }
