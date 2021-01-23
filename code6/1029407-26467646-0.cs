    class Program
    {
        static void Main(string[] args)
        {
            var Source = GetSourceDirectory();
            var Destination = GetDestinationDirectory();
            CopyDirectory(Source, Destination);
            Console.WriteLine("\n\nFinished.");
            Console.ReadKey(true);
        }
        static DirectoryInfo GetSourceDirectory()
        {
            var verifyPath = false;
            var pathExists = false;
            var path = "";
            while(!verifyPath)
            {
                while(!pathExists)
                {
                    Console.WriteLine("Please enter the Source Directory path.");
                    path = Console.ReadLine();
                    Console.WriteLine("Verifying directory exists...");
                    pathExists = Directory.Exists(path);
                    if (!pathExists)
                        Console.WriteLine("That path does not exist.");
                }
                Console.WriteLine("Directory found.");
                Console.WriteLine("Please verify the source file path (Y or N):");
                Console.WriteLine(path);
                verifyPath = GetVerification();
            }
            return new DirectoryInfo(path);
        }
        static DirectoryInfo GetDestinationDirectory()
        {
            var verifyPath = false;
            var path = "";
            while (!verifyPath)
            {
                var pathExists = false;
                var createDir = false;
                while (!pathExists)
                {
                    Console.WriteLine("Please enter the Destination Directory path.");
                    path = Console.ReadLine();
                    Console.WriteLine("Verifying directory exists...");
                    pathExists = Directory.Exists(path);
                    if (!pathExists)
                    {
                        Console.WriteLine("Directory does not exist. Would you like to create it?");
                        createDir = GetVerification();
                        pathExists = createDir;
                    }
                    else
                        Console.WriteLine("Directory found.");
                        
                }
                Console.WriteLine("Please verify the source file path (Y or N):");
                Console.WriteLine(path);
                verifyPath = GetVerification();
                if (verifyPath && createDir)
                    Directory.CreateDirectory(path);
            }
            return new DirectoryInfo(path);
        }
        static bool GetVerification()
        {
            char[] VerificationChoices = { 'y', 'Y', 'n', 'N' };
            var VerifiedChar = Console.ReadKey().KeyChar;
            while (!VerificationChoices.Contains(VerifiedChar))
                VerifiedChar = Console.ReadKey().KeyChar;
            Console.Write("\n\n");
            return VerifiedChar == 'Y' || VerifiedChar == 'y';
        }
        static void CopyDirectory(DirectoryInfo DirectoryToCopy, DirectoryInfo Destination)
        {
            foreach(var SubFolder in DirectoryToCopy.GetDirectories())
            {
                var SubDestination = Destination.CreateSubdirectory(SubFolder.Name);
                Console.WriteLine("Creating Directory: " + SubDestination.FullName);
                CopyDirectory(SubFolder, SubDestination);
            }
            foreach(var File in DirectoryToCopy.GetFiles())
            {
                var FullDestinationPath = Destination.FullName + "\\" + File.Name + File.Extension;
                File.CopyTo(FullDestinationPath);
                Console.WriteLine("Creating File: " + FullDestinationPath);
            }
        }
    }
