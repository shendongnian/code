        public bool StringSimularity(string s1, string s2)
        {
           var res =  s1.Intersect(s2);
           if (res.Count().Equals(s2.Length) || res.Count().Equals(s1.Length))
               return true;
           else
               return false;
        }
