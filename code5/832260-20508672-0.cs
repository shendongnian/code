    private static string GetProtectedID(int id)
    {
      using(var sha = System.Security.Cryptography.SHA1.Create())
      {
        return string.Join("", sha.ComputeHash(Encoding.UTF8.GetBytes(hashString)).Select(b => b.ToString("X2"))) + id.ToString();
      }
    }
