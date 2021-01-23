    _ref = (int) Math.Floor((double)array.Count / 2); // assuming this can go negative...
    if(0 <= _ref)
    {
        for (int _j = 0; _j < _ref; _j++)
        { 
            _results1.Add(_j); 
        }
    }
    else
    {
        for (int _j = 0; _j > _ref; _j--)
        { 
            _results1.Add(_j); 
        }
    }
