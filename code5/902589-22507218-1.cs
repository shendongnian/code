    if (count > 5) 
    { 
        _offset = 5.55555;
        // I leave it to you to properly assign _offset;
        OnPropertyChanged();
        return; 
    }
        StringBuilder() sb = new StringBuilder();
        foreach (var y in formatted)
        {
            
            if (!isSeparator)
            {
                if (y == a)
                {
                    isSeparator = true;
                }
            }
            else
            {
                count++;
                if (count > 5) break;
            }
            sb.Append(y);
        }
        if (isSeparator)
        {
            if (count > 5)
            {
                _offset = Double.Parse(sb.ToString());
                OnPropertyChanged();
                return;
            }
        }
 
 
