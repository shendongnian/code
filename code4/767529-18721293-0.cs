    private int getver(int m, int n, int b)
    {
        List<ProductVersions> pv = new List<ProductVersions>();
        pv.Add(new ProductVersions { Version_Id = 3, Major = 6, Minor = 2, Build = 1 });
        pv.Add(new ProductVersions { Version_Id = 4, Major = 7, Minor = 5, Build = 1 });
        pv.Add(new ProductVersions { Version_Id = 5, Major = 10, Minor = 7, Build = 1 });
        pv.Add(new ProductVersions { Version_Id = 6, Major = 11, Minor = 10, Build = 10 });
        int mm = m;
        if (m == 0)
            mm = int.MaxValue;
        int nn = n;
        if (n == 0)
            nn = int.MaxValue;
        int bb = b;
        if (b == 0)
            bb = int.MaxValue;
        var v = pv.FindAll(mj => mj.Major <= m).FindAll(mn => n == 0 ? mn.Major <= mm - 1 && mn.Minor <= nn : mn.Minor <= n).FindAll(bl => b == 0 ? bl.Minor <= nn - 1 && bl.Build <= bb : bl.Build <= b).Last().Version_Id;
        return v;
    }
