        foreach (var v in (i as IEnumerable<object>))
        {
            if (v is KeyValuePair<string, string>)
            {
                // Do stuff
            }
            else if (v is List<string>)
            {
                //Do stuff
            }
            else throw new InvalidOperationException();
        }
