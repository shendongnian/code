    object[] results = query
      .Select(b => b.BooleanValue.Value) // on the server
      .Distinct() // on the server
      .AsEnumerable() // now we're on the client
      .Cast<object>() // box each value to object on the client
      .ToArray(); // put the results into an array of objects on the client
