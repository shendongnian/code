            public static Dictionary<string, List<string>> GetAnagramEquivalents(List<string> InputArray)
            {
                Dictionary<string,List<string>> ReturnList = new Dictionary<string,List<string>>();
                for (int x = 0; x < InputArray.Count; ++x)
                {
                    char[] InputCharArray = InputArray[x].ToCharArray();
                    Array.Sort(InputCharArray);
                    string InputString = new string(InputCharArray);
                    if (ReturnList.ContainsKey(InputString))
                    {
                        ReturnList[InputString].Add(InputArray[x]);
                    }
                    else
                    {
                        ReturnList.Add(InputString, new List<string>());
                        ReturnList[InputString].Add(InputArray[x]);
                    }
                }
                return ReturnList;
            }
