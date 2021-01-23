    byte[] bajti = HexToBytes(hex1.Text);
    char c = 'a';
    if (bajti.Length == 1)
    {
        c = (char)bajti[0];
    }
    else if (bajti.Length == 2)
    {
        c = (char)((bajti[0] << 8) + bajti[1]);
    }
    else if (bajti.Length == 3)
    {
        c = (char)((bajti[0] << 16) + (bajti[1] << 8) + bajti[2]);
    }
    else if (bajti.Length == 4)
    {
        c = (char)((bajti[0] << 24)+(bajti[1] << 16) + (bajti[2] << 8) + bajti[3]);
    }
    znak1.Text = c.ToString();
