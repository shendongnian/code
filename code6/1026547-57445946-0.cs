using System;
using System.IO;
using DiffMatchPatch;
namespace ConsoleApp_DMPTrial
{
     class Program
        {
            static void Main(string[] args)
            {
                var dmp = DiffMatchPatchModule.Default;
                string file1Content = "";
                string file2Content = "";
                using (StreamReader sr = new StreamReader("file1.json"))
                {
                    file1Content = sr.ReadToEnd();
                }
                using (StreamReader sr = new StreamReader("file2.json"))
                {
                    file2Content = sr.ReadToEnd();
                }
                
                var diffs = dmp.DiffMain(file1Content, file2Content);
    
                dmp.DiffCleanupSemantic(diffs);
    
                for (int i = 0; i < diffs.Count; i++)
                {
                    Console.WriteLine(diffs[i]);
                }
    
                Console.ReadLine();
            }
        }
}
