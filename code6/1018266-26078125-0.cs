    string S = "(1,2)(33,44)(55,66)(77,8888)";
    Regex R = new Regex(@"\((\d|\,)+\)");
    foreach (Match item in R.Matches(S))
    {
        var P = item.Value.Substring(1,item.Value.Length-2).Split(',');
        Point YourPoint = new Point(int.Parse(P[0]), int.Parse(P[1]));
        MessageBox.Show(YourPoint.ToString());
    }
