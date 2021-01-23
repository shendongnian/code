    List<int> integers = new List<int>();
    foreach (var tb in textBoxCodeContainer)
    {
        int codeValue;
        if (int.TryParse(tb.Text, out codeValue))
        {
            integers.Add(codeValue);
        }
    }
