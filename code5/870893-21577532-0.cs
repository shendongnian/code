    var pattern   = new StringBuilder("         00000000            0000000000000000 ");
    var target    = "AUEUIGHEVjerhvgm,eiouhegfwoedjkjjjjjjjjjjjjjjje";
    var workspace = new StringBuilder(target);
    for (int i = 0, n = Math.Min(pattern.Length, target.Length); i < n; ++i)
        if (pattern[i] != '0')
            workspace[i] = '0';
    string result = workspace.ToString();
