            //you can change in to MathOper
            List<Tuple<int, char>> result = new List<Tuple<int, char>>(); 
            string _mathString = "2-2+10-13"; //Test
            char sign = '-';
            if (_mathString[0] != '-') //checking the first sign
            {
                sign = '+';
            }
            while (_mathString.Length > 0)
            {
                int nextPl = _mathString.IndexOf('+');
                int nextMn = _mathString.IndexOf('-');
                if (nextPl == -1 && nextMn == -1) //condition when _mathString contains only number
                {
                    result.Add(new Tuple<int, char>(int.Parse(_mathString), sign));
                    break;
                }
                else
                {
                    //getting the end position of first number
                    int end = nextPl == -1 ? nextMn : (nextMn == -1 ? nextPl : (Math.Min(nextPl, nextMn)));
                    //retrieving first number
                    result.Add(new Tuple<int, char>(int.Parse(_mathString.Substring(0, end)), sign));
                    _mathString = _mathString.Remove(0, end);
                    //retrieving next sign
                    sign = _mathString[0];
                    _mathString = _mathString.Remove(0, 1);
                }
            }
