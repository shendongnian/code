    public static IEnumerable<char> RemoveDiacriticsEnum(string src, string alphabet)
    {
      foreach(char c in src.Normalize(NormalizationForm.FormD))
        if(alphabet.Contains(c))  // Catch e.g. Ñ in Spanish, considered letter in own right
          yield return c;
        else
          switch(CharUnicodeInfo.GetUnicodeCategory(c))
          {
            case UnicodeCategory.NonSpacingMark:
            case UnicodeCategory.SpacingCombiningMark:
            case UnicodeCategory.EnclosingMark:
              //do nothing
              break;
            default:
              yield return customFolding(c);
              break;
          }
    }
