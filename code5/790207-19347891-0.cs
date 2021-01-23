    string a = "Result Set 25: 171 companies";
    string b = string.Empty;
    int val;
    for (int i = 0; i < a.Length; i++)
    {
        if (Char.IsDigit(a[i]))
            b += a[i];
        else if (b.Length != 0)
            break;
    }
    if (b.Length > 0)
    val = int.Parse(b);
