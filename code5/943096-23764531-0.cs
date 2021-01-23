    public ActionResult Index()
    {
        //creating a DirectoryInfo object
        DirectoryInfo mydir = new DirectoryInfo(@"\\edcapptest\E$\cdn\js\jquery");
        // getting the files in the directory
        FileInfo[] f = mydir.GetFiles();
        List<string> myList = new List<string>();
        foreach (FileInfo file in f)
        {
            myList.Add(file.Name);
        }
        myList.Sort(SortByModificationDate);
        return View(myList);
    }
    public int SortByModificationDate(string file1, string file2)
    {
        DateTime time1 = File.GetLastWriteTime(file1);
        DateTime time2 = File.GetLastWriteTime(file2);
        return time1.CompareTo(time2);
    }
