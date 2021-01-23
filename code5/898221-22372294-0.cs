    using System;
       namespace ConsoleApplication1
       {
        class Program
        {
        
    
            static void Main(string[] args)
            {
                string emailsubject = "Email Test 2 CRM:0276002";
    
                emailsubject = GetCrmSubjectNum(emailsubject);
    
                Console.WriteLine(emailsubject);
                Console.Read();
            }
            public static string GetCrmSubjectNum(string emailsubject)
            {
               emailsubject = emailsubject.Remove(0, emailsubject.IndexOf("CRM"));
                return emailsubject;
            }
        }
    }
