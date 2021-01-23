    public static SecureString ToSecureString(string source)
    {
          if (string.IsNullOrWhiteSpace(source))
                return null;
          else
          {
                SecureString result = new SecureString();
                foreach (char c in source.ToCharArray())
                    result.AppendChar(c);
                return result;
          }
    }
