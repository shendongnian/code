    public bool IsInPattern(int inputToTest, string pattern)
    {
        var numbers = new List<int>();
        var tokens = pattern.Split(new []{",", " ", "or"}, 
                                   StringSplitOptions.RemoveEmptyEntries);
        bool to_flag = false;
        foreach(var t in tokens)
        {
            int n;
            if (Int32.TryParse(t, out n))
            {
                if (to_flag) 
                    numbers.AddRange(Enumerable.Range(numbers.Last() + 1, 
                                                      n - numbers.Last()));
                else 
                    numbers.Add(n);
                to_flag = false;
            }
    		else if (t == "to") to_flag = true;
            else throw new Exception("invalid pattern");
        }
    	return numbers.Contains(inputToTest);
    }
