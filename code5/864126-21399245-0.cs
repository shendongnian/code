      public static class StringFormatExtensions {
        public static String NamedFormat(this String value, IDictionary<String, String> data) {
          if (String.IsNullOrEmpty(value))
            return value;
    
          StringBuilder Sb = new StringBuilder();
          StringBuilder Key = new StringBuilder();
    
          Boolean inBraces = false;
          Boolean SkipClose = false;
    
          foreach (Char Ch in value) {
            if (inBraces) {
              if (Ch == '{') {
                if (Key.Length <= 0) {
                  inBraces = false;
                  Sb.Append('{');
                }
                else
                  Key.Append(Ch);
              }
              else if (Ch == '}') {
                inBraces = false;
    
                String item;
    
                if (Object.ReferenceEquals(null, data))
                  throw new ArgumentNullException("data");
                else if (!data.TryGetValue(Key.ToString(), out item))
                  throw new FormatException("Key {" + Key.ToString() + "} not found");
                else if (!Object.ReferenceEquals(null, item))
                  Sb.Append(item.ToString());
    
                Key.Clear();
              }
              else
                Key.Append(Ch);
            }
            else if (Ch == '{') {
              inBraces = true;
              SkipClose = true;
            }
            else if (Ch == '}')
              if (!SkipClose) {
                Sb.Append(Ch);
                SkipClose = true;
              }
              else
                SkipClose = false;
            else {
              Sb.Append(Ch);
              SkipClose = false;
            }
          }
    
          if (inBraces)
            throw new FormatException("Unclosed } in the string.");
    
          return Sb.ToString();
        }
      }
