       public static String GetAllEncodings(String value) {
          List<Encoding> encodings = new List<Encoding>();
    
          // Ordinary code pages
          foreach (EncodingInfo info in Encoding.GetEncodings()) 
            encodings.Add(Encoding.GetEncoding(info.CodePage));
    
          // Special encodings, that could have no code page
          foreach (PropertyInfo pi in typeof(Encoding).GetProperties(BindingFlags.Static | BindingFlags.Public))
            if (pi.CanRead && pi.PropertyType == typeof(Encoding))
              encodings.Add(pi.GetValue(null) as Encoding);
    
          foreach (Encoding encoding in encodings) {
            Byte[] data = Encoding.UTF8.GetBytes(value);
            String test = encoding.GetString(data).Replace('\0', '?');
    
            if (Sb.Length > 0)
              Sb.AppendLine();    
    
            Sb.Append(encoding.WebName);
            Sb.Append(" (code page = ");
            Sb.Append(encoding.CodePage);
            Sb.Append(")");
    
            Sb.Append(" -> ");
            Sb.Append(test);
          }
    
          return Sb.ToString();
        }
    
        ...
    
    
    // Test / usage
    
        String St = "Некий русский текст";      // <- Some Russian Text
        Byte[] d = Encoding.UTF32.GetBytes(St); // <- Was encoded as UTF 32
        St = Encoding.UTF8.GetString(d);        // <- And erroneously read as UTF 8
    
        // Let's see all the encodings:
        myTextBox.Text = GetAllEncodings(St);
    
        // In the myTextBox.Text you can find the solution:
        // ....
        // utf-32 (code page = 12000) -> Некий русский текст
        // ....
