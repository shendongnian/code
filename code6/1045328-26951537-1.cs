    List<int> ids = new List<int>();
    foreach(int x in lbTestSubjects.SelectedIndices)
    {
        TestSubject t = lbTestSubjects.Items[x] as TestSubject ;
        ids.Add(t.TestSubjectID);
    }
    string result = string.Join(",", ids);
    Console.WriteLine(result);
