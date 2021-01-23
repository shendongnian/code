                int number = 212345678;
                string semiRes = number.ToString();
                var lastThree = semiRes.Substring(semiRes.Length - 3, 3);
                List<string> resulatArray = new List<string>();
                resulatArray.Add(lastThree);
                semiRes = semiRes.Substring(0, semiRes.Length - 3);
                for (int i = 2; i <= semiRes.Length + 2; i = i + 2)
                {
                    var start = semiRes.Length - i;
                    var len = 2;
                    if (start < 0)
                    {
                        len = 2 + start;
                        start = 0;
                    }
                    var nextTwo = semiRes.Substring(start, len);
                    resulatArray.Insert(0, nextTwo);
                }
                var result = string.Join(",", resulatArray);
                if (result.StartsWith(","))
                {
                    result = result.Substring(1);
                }
