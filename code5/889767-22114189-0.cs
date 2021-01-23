    using System;
    using System.IO;
     
    namespace FileAccess
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                string FileName="TestFile.txt";
     
                // Open the file into a StreamReader
                StreamReader file = File.OpenText(FileName);
                // Read the file into a string
                string s = file.ReadToEnd();
                // Close the file so it can be accessed again.
                file.Close();
     
                // Add a line to the text
                s  += "A new line.\n";
     
                // Hook a write to the text file.
                StreamWriter writer = new StreamWriter(FileName);
                // Rewrite the entire value of s to the file
                writer.Write(s);
     
                // Add a single line
                writer.WriteLine("Add a single line.");
     
                // Close the writer
                writer.Close();
            }
        }
    }
