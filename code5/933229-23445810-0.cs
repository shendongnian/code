            char lastChar = default(char);
            List<List<char>> result = new List<List<char>>();
            foreach (var c in inputString)
            {
                if(c != lastChar)
                    result.Add(new List<char>());
                result.Last().Add(c);
                lastChar = c;
            }
            var r = result.Select(p => new string(p.ToArray())).ToList();
