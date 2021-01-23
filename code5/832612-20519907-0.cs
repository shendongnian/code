    ([\w ]\S+\/*)*\w([\w]+\.(\w+))
    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        public static void Main()
        {
            string patternDir = @"([\w ]\S+\/*)*\w([\w]+\.(pj))";
            
            string pathDir = @"d:\ARCTest\_MyProject\Sources\CMInterfaces\project.pj subsandbox ";
    		string pathFile = @"CMAccess.sln archived";
    
            Console.WriteLine((Regex.IsMatch(pathDir,patternDir))? "It's dir!" : "It's not a dir");
    		Console.WriteLine((Regex.IsMatch(pathFile,patternDir))? "It's dir!" : "It's not a dir");
    		
            Console.ReadKey();
        }
    }
