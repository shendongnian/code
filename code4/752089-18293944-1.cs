    public static void Main(String[] args)
    {
        ... some input checking ...
    
        string ZipFileToCreate = args[0];
        string DirectoryToZip = args[1];
        try
        {
            using (ZipFile zip = new ZipFile())
            {
                // note: this does not recurse directories! 
                String[] filenames = System.IO.Directory.GetFiles(DirectoryToZip);
                foreach (String filename in filenames)
                {
                    Console.WriteLine("Adding {0}...", filename);
                    ZipEntry e = zip.AddFile(filename);
                    e.Comment = "Added by Cheeso's CreateZip utility.";
                }
    
                zip.Save(ZipFileToCreate);
            }
        }
        catch (System.Exception ex1)
        {
            System.Console.Error.WriteLine("exception: " + ex1);
        }
    }
