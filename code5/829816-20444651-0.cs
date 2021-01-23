    using System;
    using System.IO;
    
    namespace FileLocator
    {
     class Program
     {
      static void Main(string[] args)
      {
       string filename = "wmplayer.exe";// Only for example.Change to your exe's name.
       string searchFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86).Replace("Common Files", "");// ProgramFiles (x86) folder
       foreach (string directory in Directory.GetDirectories(searchFolder))// Iterate through each folder in PFx86.
       {
        foreach (string directoryfilename in Directory.GetFiles(directory, "*.exe"))// Get all files with .exe extension.
        {
         if (Path.GetFileName(directoryfilename) == filename)//If Current filename==wmplayer.exe
         {
          Console.WriteLine("Found {0} in {1}", filename, directory);
          Console.WriteLine("Complete Path => {0}", directoryfilename);
          Console.ReadLine();
         }
        }
       }
    }
    }
    }
