    public class situation 
    {
          public string Terminal 
          {
             get{ return term;}
          }
          public int Pos
          {
             get{ return pos;}
          }
          public override bool Equals(object obj)
          {
             bool result;
             situation s = obj as situation;
             if (s != null)
             {
                result = Terminal.Equals(s.Terminal) && Pos == s.Pos;
             }
    
             return result;
          }
    }
