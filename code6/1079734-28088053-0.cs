      List<int> a = new List<int>();
        a.Add(1 ) ;
        a.Add(2);
        List<int> b = new List<int>();
        b.Add(5) ;
        b.Add(6);
        List<int> c = new List<int>();
        for (int x = 0; x < a.Count; x++)
        {
            c.Add(a[x] + b[x]);
            Label1.Text += c[x] + "";
        }
