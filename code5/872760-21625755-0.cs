    interface ISwitch
    {
          IEnumerable<object> CaseValues{get;}
    }
    class Switch<T> : ISwitch
    {
          // .... your code ....
          
          IEnumerable<object> ISwitch.CaseValues{get{ return Case.Values.Cast<object>(); }}
    }
