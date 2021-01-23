    private static string Base64UrlEncode(string input) {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        // Special "url-safe" base64 encode.
        return Convert.ToBase64String(inputBytes)
          .Replace('+', '-') // replace URL unsafe characters with safe ones
          .Replace('/', '_') // replace URL unsafe characters with safe ones
          .Replace("=", ""); // no padding
      }
