    /// <summary>
    /// User-defined collating sequence using the current UI culture.
    /// </summary>
    [SQLiteFunction(Name = "MYSEQUENCE", FuncType = FunctionType.Collation)]
    class MySequence : SQLiteFunction
    {
      public override int Compare(string param1, string param2)
      {
        return String.Compare(param1, param2, true);
      }
    }
