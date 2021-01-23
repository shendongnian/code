    Stopwatch stp = new Stopwatch();
    stp.Start();
    for (int i = 0; i < 1000000; i++)
    {
        string input = "ThisIsMySample";
        string result = System.Text.RegularExpressions.Regex.Replace(input, "(?<=.)([A-Z])", "_$0",
                System.Text.RegularExpressions.RegexOptions.Compiled);
    }
    stp.Stop();
    MessageBox.Show(stp.ElapsedMilliseconds.ToString());
    // Result 2569ms
    Stopwatch stp2 = new Stopwatch();
    stp2.Start();
    for (int i = 0; i < 1000000; i++)
    {
        string input = "ThisIsMySample";
        string result = string.Concat(input.Select((x, j) => j > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
    }
    stp2.Stop();
    MessageBox.Show(stp2.ElapsedMilliseconds.ToString());
    // Result: 1489ms
