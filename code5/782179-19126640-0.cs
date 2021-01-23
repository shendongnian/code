    // Individual Parameter Values 
    class ParameterValueClass { 
       double _Value; 
       double _Max; 
       public double Value { get { return (_Value < _Max) ? _Value : _Max }
                             set  { _Value = value; } } 
       public ParameterValueClass(Max) { _Max = Max; } 
     } 
    // Set of Parameter Values 
    class ParameterSetClass { 
          public ParameterValueClass Parameter1;
          public ParameterValueClass Parameter2;
          public ParameterValueClass Parameter3;
          public ParameterSetClass () { 
              Parameter1 = new ParameterValueClass(20);
              Parameter2 = new ParameterValueClass(4.22314);
              Parameter3 = new ParameterValueClass(700000);
          }
     } 
   
    void ExampleMethod(ParameterSetClass Parameters) {
        /// Parameter1.Value returns the Value or "Max" value. Could also use a min value. 
      }
