    class Student
    {
       public string Name {get; set;}
       public int Age {get; set;}
       public int Height {get; set;}
       public Student() {} //you would need parameterless constructor to use "new Student {...}"
       public Student(string name, int age, int height)
       {
          Name = name;
          Age = age;
          Height = height;
       }
    }
    var Students = new List<Student>() 
                       { 
                          new Student { Name = "A", Age = 29, Height = 175 },  //using initializer
                          new Student("B", 30, 176), //using constructor
                          ... 
                       };
