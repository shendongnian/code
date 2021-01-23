       private Dictionary<string, int> _maxlengthValues;
       public Dictionary<string, int> MaxLengthValues
       {
           get
           {
               if (_maxlengthValues == null)
               {
                 // horrible example, but does the job
                _maxlengthValues =  this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                       .ToDictionary(n => n.Name, p => p.GetCustomAttributes(typeof(DefaultValueAttribute), false))
                       .Where(p => p.Value != null && p.Value.Any() && (p.Value[0] as DefaultValueAttribute).Value != null)
                       .ToDictionary(k => k.Key, v=>(int)(v.Value[0] as DefaultValueAttribute).Value);
               }
               return _maxlengthValues;
           }
       }
      [DefaultValue(20)] // 20 char limit
      public string TestString
      {
          get { return _testString; }
          set { _testString = value; NotifyPropertyChanged("TestString"); }
      }
