      Dictionary<int, String> diags = ...;
    
      foreach (var pair in diags) {
        // if p1..p30 are fields use FieldInfo instead of PropertyInfo
        // FieldInfo pi = proc.GetType().GetField("x" + pair.Key.ToString());
        PropertyInfo pi = proc.GetType().GetProperty("x" + pair.Key.ToString());
    
        if (!Object.ReferenceEquals(null, pi))
          pi.SetValue(proc, pair.Value);
      }
      proc.Calc();
