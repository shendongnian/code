    public class Token
    {
      private readonly string _tokenText;
      private string _val;
      private int _begin, _end;
      public Token(string tk, int beg, int end)
      {
       this._tokenText = tk;
       this._begin = beg;
       this._end = end;
       this._val = String.Empty;
      }
      
      public string TokenText
      {
       get{ return _tokenText; }
      }
      
      public string Value
      {
       get { return _val; }
       set { _val = value; }
      }
      
      public int IdxBegin
      {
       get { return _begin; }
      }
      
      public int IdxEnd
      {
       get { return _end; }
      }
    }
