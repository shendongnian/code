    List<string> xList; //Contains 300 string
    int N = 100;
    int counter = 0;
    
    for (int i = 1; i < = xList.Count; i++)
    {
        var vList = xList.Skip(counter).Take(N);
        MessageBox.Show(string.Join(Environment.NewLine, vList.ToArray()));
        counter += N;
    }
