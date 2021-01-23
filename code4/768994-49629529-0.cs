    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace CreateCsv
    {
        class Program
        {
            static void Main()
            {
                // Set the path and filename variable "path", filename being MyTest.csv in this example.
                // Change SomeGuy for your username.
                string path = @"C:\Users\SomeGuy\Desktop\MyTest.csv";
    
                // Set the variable "delimiter" to ", ".
                string delimiter = ", ";
    
                // This text is added only once to the file.
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    string createText = "Column 1 Name" + delimiter + "Column 2 Name" + delimiter + "Column 3 Name" + delimiter + Environment.NewLine;
                    File.WriteAllText(path, createText);
                }
    
                // This text is always added, making the file longer over time
                // if it is not deleted.
                string appendText = "This is text for Column 1" + delimiter + "This is text for Column 2" + delimiter + "This is text for Column 3" + delimiter + Environment.NewLine;
                File.AppendAllText(path, appendText);
    
                // Open the file to read from.
                string readText = File.ReadAllText(path);
                Console.WriteLine(readText);
            }
        }
    }
