    string Lazy<string> _largeCalculatedVariable = null;//No need to set it to null but whatever you prefer
    public string largeCalculatedVariable
       {
           get
           {
               if (_largeCalculatedVariable == null)
               {
                  _largeCalculatedVariable = new Lazy<string>(()=>
                  {
                     _largeCalculatedVariable = LongRunningCalculate();
                  }
               }
               return _largeCalculatedVariable.Value
           }
       }
