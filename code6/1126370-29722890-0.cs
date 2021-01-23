    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace EDXonline_AssignmentFour
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                student[] studentArray = new student[5];
                studentArray[0].FirstName = "einstein";
                studentArray[0].LastName = "makuyana";
                 DateTime date1 = new DateTime(1993, 11, 22, 02, 00, 0);
                 studentArray[0].Birthdate = date1;
    
    
                Console.WriteLine("student First Name: {0}", studentArray[0].FirstName);
                Console.WriteLine("student Last Name: {0}", studentArray[0].LastName);
                Console.WriteLine("student birthday: {0}", studentArray[0].Birthdate.ToString());
    
                Console.ReadKey();
    
            }
    
            public struct student
            {
                // This is the custom constructor.
                public student(string firstname, string lastname, DateTime birthdate)
                   {
                      this.FirstName = firstname;
                      this.LastName = lastname;
                      this.Birthdate = birthdate;
                   }
                   // These statements declare the struct fields and set the default values.
                   public string FirstName;
                   public string LastName;
                   public DateTime Birthdate;
            }
