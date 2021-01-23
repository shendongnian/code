    public static string ReplaceSpecifiedIndex(this string input, string valueToBeReplaced, string replacingvalue, int index)
      {
                input = input.ToLower();
                valueToBeReplaced = valueToBeReplaced.ToLower();
                replacingvalue = replacingvalue.ToLower();
                Match m = Regex.Match(input, "((" + valueToBeReplaced + ").*?){" + index + "}");
                int specificIndex = -1;
                if (m.Success)
                    specificIndex = m.Groups[2].Captures[index - 1].Index;
    
         if (specificIndex > -1)
         {
                    string temp = input.Substring(specificIndex, valueToBeReplaced.Length);
                    int nextsubstring = specificIndex + valueToBeReplaced.Length;
                    input = input.Substring(0, specificIndex) + temp.Replace(valueToBeReplaced, replacingvalue) + input.Substring(nextsubstring);
          }
          return input;
      }
