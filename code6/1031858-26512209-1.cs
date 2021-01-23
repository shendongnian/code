    string strTextFileName = @"C:\Users\Public\test1.txt";
    int iInsertAtLineNumber = 2;
    string strTextToInsert = @"C:\Users\Public\test2.txt";
    ArrayList lines = new ArrayList();
    
    lines.AddRange(GetFileLines(strTextFileName));
    
    lines.InsertRange(iInsertAtLineNumber, GetFileLines(strTextToInsert));
    
    using (var wrtr = new StreamWriter(strTextFileName))
    {
        foreach (string strNewLine in lines)
            wrtr.WriteLine(strNewLine);
    }
