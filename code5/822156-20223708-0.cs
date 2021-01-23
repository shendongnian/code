    class Person
    {
      public string Name;
      
      public string Process(string expression)
      {
        return CsEval.Eval(this, expression);
      }
    }
