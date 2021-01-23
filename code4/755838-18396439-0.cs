     for (int i = 0; i < s.Length; i += length)
        {
            int index=s.IndexOf(" ",i, s.Length-i)
    
            if (i + length + index <= s.Length)
            {
                i+=index;           
                yield return s.Substring(index, length);
            }
            else
            {
                yield return s.Substring(i);
            }
        }
