    public void Add(string firstName, string lastName)
    {
      for (int i = 0; i < _lastNames.Count; i++)
      {
        if (lastName.CompareTo(_lastNames.Items[i]) >= 0)
        {
          _lastNames.Insert(i, lastName);
          _firstNames.Insert(i, firstName);
          break;
        }
      }
    }
