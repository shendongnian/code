    public static class ReplaceHelper
    {
    public static string ReplaceAt(this string input, int index, char newChar)
      {
        if (input == null)
        {
          throw new ArgumentNullException("input");
        }
        char[] chars = input.ToCharArray();
        chars[index] = newChar;
        return new string(chars);
      }
    }
