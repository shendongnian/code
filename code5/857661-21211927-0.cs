    class RtfBuilder { 
      StringBuilder _builder = new StringBuilder();
    
      public void AppendBold(string text) { 
        _builder.Append(@"\b ");
        _builder.Append(text);
        _builder.Append("\b0 ");
      }
    
      public void Append(string text) { 
        _builder.Append(text);
      }
    
      public void AppendLine(string text) { 
        _builder.Append(text);
        _builder.Append(@"\line");
      }
    
      public string ToRtf() { 
        return @"{\rtf1\ansi " + ToString() + @" }";
      }
    }
