    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                //set the path to check:
                var path = @"D:\Thefiles";
                //create a dictionary to store the results so we can also remember the file name
                var results = new Dictionary<int, string>();
                //loop all the files
                foreach (var file in Directory.GetFiles(path))
                {
                    //get the name without any extension
                    var namePart = Path.GetFileNameWithoutExtension(file);
                    //try to cast it as an integer; if this fails then we can't count it so ignore it
                    int fileNumber = 0;
                    if (Int32.TryParse(namePart, out fileNumber))
                    {
                        //add to dictionary
                        results.Add(fileNumber, file);
                    }
                }
                //only show the largest file if we actually have a result
                if (results.Any())
                {
                    var largestFileName = results.OrderByDescending(r => r.Key).First();
                    Console.WriteLine("Largest name is {0} and the file name is {1}", largestFileName.Key, largestFileName.Value);
                }
                else
                {
                    Console.WriteLine("No valid results!");
                }
                Console.ReadLine();
            }
        }
    }
