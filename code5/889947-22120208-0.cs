    var b = new byte[] {252, 2, 56, 8, 9};
    var g = new char[b.Length];
    var f = new byte[g.Length]; // can also be b.Length, doens't really matter
    for (int i = 0; i < b.Length; i++)
    {
       g[i] = Convert.ToChar(b[i]);
    }
    for (int i = 0; i < f.Length; i++)
    {
       f[i] = Convert.ToByte(g[i]);
    }
       
