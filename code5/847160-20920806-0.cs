    public class Two
    {
        public string Three {get;set;}
     }
      public class One
      {
           public Two Two {get;set;}
       }
      public class Abc
      {
          public One One {get;set;}
       }
       //result.One.Two.Three
