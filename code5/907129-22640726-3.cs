    // lots of explicity (is that a word? :)
    public MyClass
    {
      // Field
      // It is recommended to never expose these as public
      private int _myField; 
      // Property (old school, non-auto private field)
      public int MyProperty
      {
        public get
        {
          return this._myField;
        }
        public set
        {
          this._myField = value;
        }
      }
      // Property (new school, auto private field)
      // (auto field cannot be accessed in any way)
      public int MyProperty2 { public get; private set; }
      // Method (these are not needed to get/set values for fields/properties.
      public int GetMyMethod()
      {
        return this._myField;
      }
    }
    var myClass = new MyClass;
    
    // this will not compile,
    // access modifier says private
    // Set Field value
    myClass._myField = 1;  
    // Get Property Value
    var a = myClass.MyProperty;
    // Set Property Value
    myClass.MyProperty = 2;
    // Get Property Value
    var b = myClass.MyProperty2;
    // this will not compile
    // access modifier says private
    // Set Property Value
    myClass.MyProperty2 = 3;
    // Call method that returns value
    var c = myClass.GetMyMethod();
