    List<String> xList; //Contains 300 string
    Int N = 100;
    Int counter = 0;
    
    for (int i = 1; i < = xList.Count; i++)
        {
            var vList = xList.Skip(counter).Take(N);
            MessageBox.Show(string.Join(Environment.NewLine, vList.ToArray()));
            counter += N;
        }
