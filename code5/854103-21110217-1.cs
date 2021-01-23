    List<char> data = new List<char>();
    string saltFull = "";
    string hexFull = "";
    char[] saltChars = salt.ToCharArray();
    for (int i = 0; i < (salt.Length / 2); i++)
    {
        string hexSalt = saltChars[i * 2].ToString() + saltChars[(i * 2) + 1].ToString();
        saltFull += hexSalt;
        int hex = int.Parse(hexSalt, NumberStyles.HexNumber);
        hexFull += hex.ToString();
        char chr = Char.ConvertFromUtf32(hex);
        data.Add(chr);
    }
    Response.Write(saltFull + "<br />"); // Same output
    Response.Write(hexFull + "<br />"); // Same output
    char[] dataArray = data.ToArray();
    Response.Write(dataArray, 0, dataArray.Length);
