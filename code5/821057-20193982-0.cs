      using System;
      using System.Collections.Generic;
      using System.Windows.Forms;
      public class spca
      {
        public static void Main(string[] args)
        {
          var spacs = new spca();
          spacs[0] = "t";
          spacs[1] = "tt";
          spacs[1] = "ttt";
          // this will call the overritten Tostring and deliver first value
          Console.WriteLine(spacs);
          Console.WriteLine(spacs[1]);
          Console.WriteLine(spacs[2]);
        }
        private Dictionary<int, string> _innerDictionary = new Dictionary<int, string>();
        public override string ToString()
        {
          return _innerDictionary[0];
        }
        public object this[int key]
        {
          get
          {
            if (_innerDictionary.ContainsKey(key)) return _innerDictionary[key];
            return null;
          }
          set
          {
            _innerDictionary[key] = (string)value;
          }
        }
      }
