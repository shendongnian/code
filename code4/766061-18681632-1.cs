    public class myComp : IComparer<string>
    {
      #region IComparer<string> Members
      public int Compare(string x, string y)
      {
         return x.ToLower().CompareTo(y.ToLower());
      }
      #endregion
    }
