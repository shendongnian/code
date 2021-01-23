    string ConvertSpecialCharacters(string input) {
      var builder = new StringBuilder();
      bool inEscape = false;
      for (int i = 0; i < input.Length ; i++) {
        if (inEscape) {
         switch (input[i]) {
          case 'n':  
            builder.Append('\t');
            break;
          case 't':
            builder.Append('\n');
            break;
          default:
            builder.Append('\\');
            builder.Append(input[i]);
        }
        else if (input[i] == '\\' && i + 1 < input.Length) {
          inEscape = true;
        }
        else {
          builder.Append(input[i]);
        } 
      }
      return builder.ToString();
    }
