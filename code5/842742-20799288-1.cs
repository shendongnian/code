    static public string MakePassword(string st, string Identifier)
    {
    if (Identifier.Length != 3)
        throw new ArgumentException("Identifier must be 3 character length");
    int[] num = new int[3];
    num[0] = Convert.ToInt32(Identifier[0].ToString(), 10);
    num[1] = Convert.ToInt32(Identifier[1].ToString(), 10);
    num[2] = Convert.ToInt32(Identifier[2].ToString(), 10);
    st = Boring(st);
    st = InverseByBase(st, num[0]);
    st = InverseByBase(st, num[1]);
    st = InverseByBase(st, num[2]);
    StringBuilder SB = new StringBuilder();
    foreach (char ch in st)
    {
        SB.Append(ChangeChar(ch, num));
    }
    return SB.ToString();
    } 
