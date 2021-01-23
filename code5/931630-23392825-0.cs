        public static List<int>  GetPositions(string haystack , string needle)
        {
            List<int> ret = new List<int>();
            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle))
                return ret;
            for(int i=0;i<haystack.Length-needle.Length+1;i++)
            {
                int j = 0;
                for(;j<needle.Length && haystack[i+j]==needle[j];j++);
                if(j==needle.Length )
                    ret.Add(i);
            }
            return ret;
        }
