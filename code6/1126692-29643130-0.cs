    ...
    using System.IO;
    using System.Text.RegularExpressions;
    ...
    
    string path = @"C:\temp";
    Regex numExtRegex = new Regex(@"^(.*)(\.\d+)$");
    foreach (string file in Directory.GetFiles(path))
    {
        Match match = numExtRegex.Match(file);
        if (match.Success)
        {
            string originalFile = match.Groups[1].Value;
            string numericExtension = match.Groups[2].Value;
            string originalFileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFile);
            string extension = Path.GetExtension(originalFile);
            Console.WriteLine("File: {0}, numeric extension: {1}, file name w/o ext: {2}, ext: {3}", 
                    originalFile, numericExtension, originalFileNameWithoutExtension, extension);
        }
    }
    
