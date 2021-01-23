     public static string GetDefaultExtension(string mimeType)
        {
          string result;
          RegistryKey key;
          object value;
    
          key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
          value = key != null ? key.GetValue("Extension", null) : null;
          result = value != null ? value.ToString() : string.Empty;
    
          return result;
        }
