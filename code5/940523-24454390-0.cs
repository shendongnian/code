    private static string RemoveEntityFrameworkMetadata(string efConnection)
    {
      int start = efConnection.IndexOf("\"", StringComparison.OrdinalIgnoreCase);
      int end   = efConnection.LastIndexOf("\"", StringComparison.OrdinalIgnoreCase);
      // We do not want to include the quotation marks
      start++;
      int length = end - start;
      string pureSqlConnection = entityFrameworkConnection.Substring(start, length);
      return pureSqlConnection;
    }
