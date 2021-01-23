    public static bool ProcessDirectory(string targetDirectory, List<string> foundFiles, List<string> errorFiles)
    {
        try
        {
            // Process the list of files found in the directory.
            string [] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                if (foundFiles.Count() >= maxcheck)
                {
                    ConsoleKeyInfo answer;
                    Console.Clear();
                    Console.SetCursorPosition(2, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0} files has been searched.", maxcheck);
                    Console.Write("  Do you wish to continue (Y/N): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    answer = Console.ReadKey();
                    Console.Clear();
                    if (answer.Key == ConsoleKey.Y)
                    {
                        maxcheck = maxcheck + 1000;
                    }
                    if (answer.Key == ConsoleKey.N)
                    {
                        return false;
                    }
                }
                else
                {
                    ProcessFile(fileName, foundFiles, errorFiles);
                }
            }
            // Recurse into subdirectories of this directory.
            string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                if (!ProcessDirectory(subdirectory, foundFiles, errorFiles))
                    return false;
            return true;
        }
        catch (Exception)
        {
            errorFiles.Add(targetDirectory);
            return false; // or true if you want to continue in the face of exceptions.
        }
    }
