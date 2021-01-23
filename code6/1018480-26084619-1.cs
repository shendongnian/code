    // using System;
    // using System.IO;
    byte[] fileContents = File.ReadAllBytes(filePath);
    byte[] reversedFileContents = Array.Reverse(fileContents);
    … // process `reversedFileContents` instead of an input file stream
