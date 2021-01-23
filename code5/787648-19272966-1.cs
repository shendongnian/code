    TextWriter w_Test = new StreamWriter(file_test);
    foreach (string results in searchResults)
    {
        int noLinesOutput = 0;
        w_Test.WriteLine(Path.GetFileNameWithoutExtension(results));
        noLinesOutput++;
        var list1 = File.ReadAllLines(results).Skip(10);
        foreach (string listResult in list1)
        {
            w_Test.WriteLine(listResult);
            noLinesOutput++;
        }
        for ( int i = 20; i > noLinesOutput; i-- )
            w_Test.WriteLine();
    }
    w_Test.Close();
