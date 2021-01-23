    var something = new List<int>();    
     if (typeof(IEnumerable).IsAssignableFrom(something.GetType()))
     {
          throw new ArgumentOutOfRangeException("Cannot create a key from type IEnumerable");
     }
