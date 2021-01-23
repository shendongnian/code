    for (int counter = 0; i < _interestlist.Count; counter++)
    {
        if (!interest[counter].active)
        {
            _interestlist.Remove(interest[counter]);
        }
    }
