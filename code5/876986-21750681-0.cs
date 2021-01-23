     public int CommonCharacterCount(string s1, string s2)
                { 
                    var r=0;
                    Dictionary<char,int> s2Dict = new Dictionary<char,int>();
                    foreach (var ch in s2)
                    {
                        if (s2Dict.ContainsKey(ch))
                            s2Dict[ch] = s2Dict[ch]+1;
                        else s2Dict.Add(ch,1);
                    }
        
                    foreach (var c in s1)
                    {
                        if (s2Dict.ContainsKey(c) && s2Dict[c]>0)
                        {
                            r++;
                            s2Dict[c] = s2Dict[c] - 1;
                        }
                    }
                    return r;
                }
