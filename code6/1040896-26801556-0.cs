    using System;
    using System.Collections.Generic;
    class Program 
    {
    
        static IEnumerable<string> GetPermutations(string value) 
        {
            if (value.Length == 1) 
            {
                yield return value;
            } 
            else 
            {
                for (int i = 0; i < value.Length; ++i) 
                {
                    string a = value[i].ToString();
                    foreach (string b in GetPermutations(value.Remove(i, 1))) 
                    {
                        yield return a + b;
                    }
                }
            }
        }
        
        static int findCharsInString(string chars, string stringIn)
        {
            foreach (string to_find in GetPermutations(chars)) 
            {
                int i = stringIn.IndexOf(to_find);
                if (i != -1)
                {
                    return 1;
                }
                return 0;
            }
        }
    
    
        static void Main(string[] args) 
        {
            string lowerCase= "abcdefghijklmnopqrstuvwxyz";
            string upperCase= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numChars = "0123456789";
            string allowedSpecials = "@#$%^+()[]";
            
            string password = "MyNotAllowedPassword";
            string validPW  = "1ValidPassword!";
            
            if ((findCharsInString(lowerCase, password) + findCharsInString(lowerCase, password) + findCharsInString(lowerCase, password)  + findCharsInString(lowerCase, password)) <3)
            {
                //do something to say its an INVALID password
                Console.WriteLine("INVALID pw!!");
            }
            else
            {
                //do something to say its a VALID password
                Console.WriteLine("Valid pw!!");
            }
    
            if ((findCharsInString(lowerCase, validPW) + findCharsInString(lowerCase, validPW) + findCharsInString(lowerCase, validPW)  + findCharsInString(lowerCase, validPW)) <3)
            {
                //do something to say its an INVALID password
                Console.WriteLine("INVALID pw!!");
            }
            else
            {
                //do something to say its a VALID password
                Console.WriteLine("Valid pw!!");
            }
        }
    }
