    Class Student
    {
      public Student()
      {
         name = "xyz";
         roll = 20;
         age = 16;
      }
      
      public override string toString(){
         return "{name: " + name ", roll: " + roll + ", age: " + age + "}";
      }
      string name;
      int roll;
      int age;
    }
