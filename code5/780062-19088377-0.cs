    public class MyAuthoringScope : AuthoringScope
    {
      ...
      public override string GetDataTipText(int line, int col, out TextSpan span)
      {
            string info;
            TokenInfo tokenInfo = this._source.GetTokenInfo(line, col);
             ...
            return info;
      }
    }
