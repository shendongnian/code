    }
    else
    {
    	using (IEnumerator<T> enumerator = collection.GetEnumerator())
    	{
    		while (enumerator.MoveNext())
    		{
    			this.Insert(index++, enumerator.Current);
    		}
    	}
    }
