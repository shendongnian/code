        try 
        {
            var l = _mylist.Single(am => am.username == username);
        }
        catch(InvalidOperationException ex)
        {
            throw new InvalidOperationException("Error", e);
        }
