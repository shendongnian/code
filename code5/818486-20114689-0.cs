    using System;
    using System.Text;
    using System.Text.RegularExpressions;   // for Regex
    namespace tentitive
    {   
     class Program
     {
        static void Main(string[] args)
         { 
           string firstString = "PLNICI PERO 2165/HORNET                           ";
           string secondString = "              77.000"; 
           string toBeReplaced = "[ ]+";    // pattern to be replaced i.e. one or more occurences of   white spaces
           string replacer = " ";           // has to be replaced with only One white space 
           string neededFirstString = Regex.Replace(firstString, toBeReplaced, replacer).ToString();
           string neededSecondString = Regex.Replace(secondString, toBeReplaced, replacer).ToString();
           Console.WriteLine(neededFirstString);
           Console.WriteLine(neededSecondString);
           Console.ReadLine();
         }
      }
    }
