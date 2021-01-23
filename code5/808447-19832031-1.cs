    public bool Gewonnen() 
    {
        for (int y = 0; y < _boolArray.GetLength(0); y++)
        {
             for (int x = 0; x < _boolArray.GetLength(1); x++)
             {
                  if (_boolArray[x, y] == false)
                      return false;
                  else
                      return true;
             }
        }
    
        return false;
    }
