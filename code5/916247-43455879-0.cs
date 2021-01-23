    using OpenMcdf;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace _22916194
    {
        //http://stackoverflow.com/questions/22916194/detecing-password-protected-ppt-and-xls-documents
        class Program
        {
            static void Main(string[] args)
            {
                foreach (var file in args.Where(File.Exists))
                {
                    switch (Path.GetExtension(file))
                    {
                        case ".ppt":
                        case ".pptx":
                            Console.WriteLine($"* {file} " +  (HasPassword(file) ? "is " : "isn't ") + "passworded");
                            Console.WriteLine();
                            break;
                        default:
                            Console.WriteLine($" * Unknown file type: {file}");
                            break;
                    }
                }
                Console.ReadLine();
                
            }
            private static bool HasPassword(string file)
            {
                try
                {
                    using (var compoundFile = new CompoundFile(file))
                    {
                        var entryNames = new List<string>();
                        compoundFile.RootStorage.VisitEntries(e => entryNames.Add(e.Name), false);
                        //As far as I can see, only passworded files contain an entry with a name containing Encrypt
                        foreach (var entryName in entryNames)
                        {
                            if (entryName.Contains("Encrypt"))
                                return true;
                        }
                        compoundFile.Close();
                    }
                }
                catch (CFFileFormatException) {
                    //This is probably a .zip file (=unprotected .pptx)
                    return false;
                }
                return false;
            }
        }
    }
