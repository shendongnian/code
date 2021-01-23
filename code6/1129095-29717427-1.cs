    static StudentInfo GetStudentInfo()
    {
      // Get student details
      StudentInfo studentInfo = new StudentInfo();
    
      Console.WriteLine("Enter the student's first name: ");
      studentInfo.firstName = Console.ReadLine();
      Console.WriteLine("Enter the student's last name");
      studentInfo.lastName = Console.ReadLine();
      Console.WriteLine("Enter the students birthday");
      studentInfo.birthday = Console.ReadLine();
    
      return studentInfo;
    }
