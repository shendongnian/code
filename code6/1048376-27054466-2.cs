    private static FileInfo[] SearchFileSystem(DirectoryInfo DirInfo, List<FileInfo> FileList)
    {
        //Not needed since GetFiles can already search all directories
        //try
        //{
        //    foreach (DirectoryInfo SubdirInfo in DirInfo.GetDirectories())
        //    {
        //        SearchFileSystem(SubdirInfo, FileList);
        //    }
        //}
        //catch
        //{
        //    // do some stuff
        //}
        //Since we are passing in FileList, let's use it instead of a new list.
        try
        {
            foreach (FileInfo File in DirInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                FileList.Add(File);
            }
        }
        catch
        {
            // do some stuff
        }
        foreach (FileInfo f in FileList)
        {
            Console.WriteLine(f.FullName);
        }
        return FileList;
    }
    static void Main()
    {
        DirectoryInfo dir_info = new DirectoryInfo(@"C:\<whatever>");
        List<FileInfo> file_list = new List<FileInfo>();
        SearchFileSystem(dir_info, file_list);
        Console.WriteLine("Count is: " + FoundFiles.Count);
        //^^^^ this returns 0...why is it empty?
        Console.WriteLine("This is the debug mode. Press key to restart");
        Console.ReadKey();
    }
