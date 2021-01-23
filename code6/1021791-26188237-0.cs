    List<string> xList; //Contains 350 string
    int N = 100;
    
    for (int i = 0; i < = xList.Count; i+=100)
    {
        var vList = xList.Skip(i).Take(N);
        MessageBox.Show(string.Join(Environment.NewLine, vList.ToArray()));
        counter += N;
    }
