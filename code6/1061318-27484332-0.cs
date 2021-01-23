    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace CSV_ReadCsvColumn
    {
        class Program
        {
            private static IEnumerable<string[]> LoadCsvData(string path, params char[] separator)
            {
                return from line in File.ReadLines(path)
                       let parts = (from p in line.Split(separator, StringSplitOptions.RemoveEmptyEntries) select p)
                       select parts.ToArray();
            }
            static void Main()
            {
                IEnumerable<string[]> lines = LoadCsvData(@"file.csv", ';');
                if (lines != null)
                {
                    // Print column one.
                    foreach (var line in lines)
                        Console.WriteLine(line[0]);
                    // Print column two.
                    foreach (var line in lines)
                        Console.WriteLine(line[1]);
                }
            }
        }
    }
