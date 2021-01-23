     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
    
     namespace RegisterApp
     {
         class TimeRegister
         {
             static void Register(string[] args)
             {
                Console.WriteLine("Time of Arrival Program!");
                Console.ReadLine();
    
                string[] EmployeeName = new string[5];
    
                for (int i = 0; i < 5; ++i)
                {
                    Console.WriteLine("Welcome, Kindly enter your Name: ");
                    EmployeeName[i] = Console.ReadLine();
    
                    Console.WriteLine(DateTime.Now.ToString());
                }    
             }
         }
    }
