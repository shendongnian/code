    string num = "66 277";
    Double n = Double.Parse(num, new NumberFormatInfo { NumberDecimalSeparator = " "});
    Double nRounded = Math.Round(n, 1);
    string num1 = "108 577";
    Double n1 = Double.Parse(num1, new NumberFormatInfo { NumberDecimalSeparator = " " });
    Double n1Rounded = Math.Round(n1, 1);
