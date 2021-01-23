    // Gender according ISO/IEC 5218 
    // See: http://en.wikipedia.org/wiki/ISO/IEC_5218
    public struct Gender {
      private int m_Value;
      private Gender(int value) {
        m_Value = value;
      }
      private Gender() {
        m_Value = 0;
      }
      public int IsoValue {
        get {
          return m_Value; 
        }
      }
      public static readonly Gender Male = new Gender(1);
      public static readonly Gender Female = new Gender(2);
      
      // E.g. "XYZ Corporation"
      public static readonly Gender NotApplicable = new Gender(5);
      // E.g. "Brown" - Mr or Mrs?
      public static readonly Gender Unknown = new Gender(0);
    }
    ...
    class Person {
      public string Name { get; private set; }
      public Gender Gender { get; set; }
      public Person(string name, Gender gender) {
         Name = name;
         Gender = gender;
      }
    }
   
