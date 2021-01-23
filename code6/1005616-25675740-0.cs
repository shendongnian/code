    public bool IsNullOrEmpty(object obj)
    {
      if (obj != null) // we can't be null
      {
        var method = obj.GetType().GetMethod("GetEnumerator");
    	if (method != null) // we have an enumerator method
    	{
    	  var enumerator = method.Invoke(obj, null);
    	  if (enumerator != null) // we got the enumerator
          {
            var moveMethod = enumerator.GetType().GetMethod("MoveNext")
            if (moveMethod != null) // we have a movenext method, lets try it
              return !(bool)moveMethod.Invoke(enumerator, null); // ie true = empty, false = has elements
          }
    	}
      }
      return true; // it's empty, lets return true
    }
