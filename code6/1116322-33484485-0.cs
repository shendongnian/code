     var length = s.Length;
            if (length == 0) return false;
            var dic = new Dictionary<char, int>();
            for (var i = 0; i < length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    dic[s[i]]++;
                    continue;
                }
                dic.Add(s[i], 1);
            }
            int odd = 0;
            foreach (var pv in dic)
            {
                if (odd > 1) return false;
                if (pv.Value % 2 == 0)
                {
                    continue;
                }
                odd++;
            }
