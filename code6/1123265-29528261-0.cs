        const char stringSplit = '\n';
        public static bool contains(this string s, string cmp)
        {
            var t0l = s.IndexOf(stringSplit);
            var c0l = cmp.IndexOf(stringSplit);
    
            var d = t0l - c0l;
            if (t0l == -1 || c0l == -1 || d < 0)
                return false;
            var tc = s.Replace(stringSplit.ToString(), "");
            var cs = cmp.Split(stringSplit);
            string regS = "";
            foreach (var c in cs)
            {
                if (regS == "")
                    regS = c;
                else
                    regS += ".{" + d + "}" + c;
            }
            return Regex.IsMatch(tc, regS);
        }
