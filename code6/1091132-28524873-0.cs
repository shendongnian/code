    class InfixToPostfixConverter
        {
            private readonly Stack<string> _stack;
            private readonly string[] _input;
            private readonly Dictionary<string, int> _priorities;
            private readonly List<string> _poliz;
    
            public InfixToPostfixConverter(string input)
            {
                _input = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                _stack = new Stack<string>();
                _poliz = new List<string>();
    
                _priorities = new Dictionary<string, int>
                {
                    {"(", 0},
                    {")", 0},
                    {"[", 0},
                    {"if", 0},
                    {"flag", 0},
                    {">", 1},
                    {"<", 1},
                    {"<=", 1},
                    {">=", 1},
                    {"=", 1},
                    {"==", 1},
                    {"!=", 1},
                    {"+", 2},
                    {"-", 2},
                    {"*", 3},
                    {"/", 3},
                    {"^", 4},
                    {"@", 5}
                };
            }
    
            public string Translate()
            {
                return ConvertInfixToPostfix();
            }
    
            private string ConvertInfixToPostfix()
            {
                int countAts = 0;
    
                bool reachedElse = false;
    
                foreach (var lexeme in _input)
                {
    
                    if (lexeme.Equals("if"))
                    {
                        _stack.Push(lexeme);
                        _stack.Push("flag");
                        
                    }
    
                    else if (lexeme.Equals("else"))
                    {
                        _poliz.Add("null");
                        _poliz.Add("1B");
                        reachedElse = true;
                        _poliz[_poliz.FindIndex(x => x.Equals("null"))] = _poliz.Count.ToString();
    
                    }
    
                    else if (Regex.IsMatch(lexeme, @"[a-zA-Z][a-zA-z0-9_]*|\d+\.?\d*")
                             && !lexeme.Equals("if") && !lexeme.Equals("else"))
                    {
                        _poliz.Add(lexeme);
                        
                    }
    
                    else if (lexeme.Equals(";"))
                    {
                        if (!reachedElse)
                        {
                            while (_stack.Count != 0 && !_stack.Peek().Equals("if"))
                            {
                                _poliz.Add(_stack.Pop());
                            }
    
    
                            if (_stack.Count != 0)
                            {
                                _stack.Pop();
                            }
                        }
                        else
                        {
                            while (_stack.Count != 0)
                            {
                                _poliz.Add(_stack.Pop());
                            }
                            _poliz[_poliz.FindIndex(x => x.Equals("null"))] = _poliz.Count.ToString();
                        }
                    }
    
                    else if (lexeme.Equals(","))
                    {
                        countAts++;
                        while (_stack.Count != 0 && !_stack.Peek().Equals("["))
                        {
                            _poliz.Add(_stack.Pop());
                        }
                    }
    
                    else if (lexeme.Equals(")") || lexeme.Equals("]"))
                    {
                        var brace = lexeme.Equals(")") ? "(" : "[";
    
                        while (_stack.Count != 0 && !_stack.Peek().Equals(brace))
                        {
                            _poliz.Add(_stack.Pop());
                        }
                        _stack.Pop();
    
                        if (_stack.Peek().Equals("flag"))
                        {
                            _stack.Pop();
                            _poliz.Add((_poliz.Count + 3).ToString());
                            _poliz.Add("null");
                            _poliz.Add("3Y");
                        }
    
                        if (lexeme.Equals("]"))
                        {
                            countAts++;
                            _poliz.Add(countAts.ToString());
                            _poliz.Add(_stack.Pop());
                            countAts = 0;
                        }
                    }
    
                    else
                    {
                        if (_stack.Count != 0 && !lexeme.Equals("(") && !lexeme.Equals("["))
                        {
                            for (;
                                _stack.Count != 0 &&
                                _priorities[lexeme] <= _priorities[_stack.Peek()];
                                _poliz.Add(_stack.Pop())) {}
                        }
    
                        if (lexeme.Equals("["))
                        {
                            countAts++;
                            _stack.Push("@");
                        }
                        _stack.Push(lexeme);
                    }
                    
                }
    
    
                return _poliz.Aggregate(string.Empty, (current, x) => current + (x + " "));
            }
        }
