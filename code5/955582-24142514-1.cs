      Dictionary<int, String> diags = ...;
      Type tp = proc.GetType();
    
      foreach (var pair in diags) {
        // if p1..p30 are fields use FieldInfo instead of PropertyInfo
        // FieldInfo pi = tp.GetField("x" + pair.Key.ToString());
        PropertyInfo pi = tp.GetProperty("x" + pair.Key.ToString());
    
        if (!Object.ReferenceEquals(null, pi))
          pi.SetValue(proc, pair.Value);
      }
      proc.Calc();
