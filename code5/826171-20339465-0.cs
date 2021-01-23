    class Class
    {
    }
    
    class Teacher
    {
      public Class[] Classes { get ; }
    }
    
    class Student
    {
      public Class[] Classes { get ; }
    }
    
    class ClassComparer : IEqualityComparer<Class>
    {
      public bool Equals( Class x , Class y )
      {
        // your implementation here
      }
      public int GetHashCode( Class obj )
      {
        // your implementation here
      }
    }
