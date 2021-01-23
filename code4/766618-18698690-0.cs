    string[] AllRecs = System.IO.File.ReadAllLines(FIRST_FILE_PATH);
    string[] AllFileNames = System.IO.File.ReadAllLines(SECOND_FILE_PATH);
    Array.Sort(AllFileNames);
    for (int i = 3; i < AllRecs.Length; i += 8) 
    {
        if (Array.BinarySearch(AllFileNames, AllRecs(i) + ".exe") >= 0)
            System.Diagnostics.Process.Start(AllRecs(i) + ".exe");
  
    }
