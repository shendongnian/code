    using System.IO;
    public static string LookForDrive(string filepath) //filepath = "\\bin\\myApp.exe")
    {
        List<string> possibleLetters = new List<string>() { "A", "B", "C" }; //and so on...
        
        foreach(string driveLetter in possibleLetters)
        {
            var testPath = String.Format("{0}:\\{1}", driveLetter, filepath);
            
            if( File.Exists( testPath ) )
            {
                return testPath,
            }
        }
        
        //If you get here, no drive letter was valid.
        
        throw new Exception("Could not find the specified file on any possible drive.");
    }
