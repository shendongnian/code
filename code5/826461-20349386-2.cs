    StringBuilder sb = new StringBuilder();
    
    String message = ValidatorMethod1();
    
    if (!String.IsNullOrEmpty(message))
      sb.Append(message);
    
    message = ValidatorMethod2();
    
    if (!String.IsNullOrEmpty(message)) {
      if (sb.Length > 0)
        sb.AppendLine();
    
      sb.Append(message);
    }
