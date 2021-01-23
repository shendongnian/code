    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace PropertiesImpConsoleApp
    {
      class Student
      {
         //Declare variables
         string firstname;
         string lastname;
        //Define property for the variables
         public string FirstName
         {
             get
             {
                 return firstname;
             }
             set
             {
                 firstname = value;
             }
         }
         public string LastName
         {
             get
             {
                 return lastname;
             }
             set
             {
                 lastname = value;
             }
         }
      }
      class MyMain
      {
          public static void Main(string[] args)
          {
              Student aStudent = new Student();
              Console.WriteLine("Enter First Name");
              aStudent.FirstName = Console.ReadLine();
              Console.WriteLine("Enter LastName");
              aStudent.LastName = Console.ReadLine();
             //And to get the properties names you can do like this
              Dictionary<string, string> aDictionary = new Dictionary<string, string>();
              PropertyInfo[] allproperties = aStudent.GetType().GetProperties().ToArray();
              foreach (var aProp in allproperties)
              {
                  aDictionary.Add(aProp.Name, aProp.GetValue(aStudent, null).ToString());
              }
              foreach (KeyValuePair<string, string> pair in aDictionary)
              {
                  Console.WriteLine("{0}, {1}",
                  pair.Key,
                  pair.Value);
              }
              Console.ReadLine();
          }
       }
    }
