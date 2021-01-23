    rawCode = rawCode.Substring(2);
    if (rawCode[0] == 'x') {
        hexCode = int.Parse(rawCode.Substring(1));
    } else {
        int decCode = int.Parse(rawCode);
        hexCode = decCode.ToString("X");
    }
    char c = Char.Parse("\u" + hexCode);
