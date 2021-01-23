    var lines = System.IO.File.ReadAllLines(@"\\tsclient\T\Bbtra\wapData.txt");
    var headers = lines[0].Split(',');
    var values = lines.Last().Split(',');
    var e1 = headers.GetEnumerator();
    var e2 = values.GetEnumerator();
    while(e1.MoveNext() && e2.MoveNext())
    {
        string message = "Data: " + e1.Current.ToString() + ' ' + e2.Current.ToString();
    }
