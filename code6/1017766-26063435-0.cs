    public bool CheckForDuplicates(string value)
    {
      string[] split = value.Split('|');
      return split.Length != split.Distinct().ToArray().Length;
    }
