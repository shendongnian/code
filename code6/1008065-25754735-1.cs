    if ( m.Success )
    {
      string[] segments = m.Groups.Cast<Group>()
                          .Skip(1)
                          .SelectMany( g => g.Captures.Cast<Capture>() )
                          .Select( c => c.Value )
                          .ToArray()
                          ;
    }
