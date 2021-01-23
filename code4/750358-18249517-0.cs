    if (System.Text.RegularExpressions.Regex.IsMatch(Data, "0[xX][0-9a-fA-F]+")) {
    }
--
    public string DecryptHex(ref string Data)
    {
        string inData = string.Empty;
        if (System.Text.RegularExpressions.Regex.IsMatch(Data, "0[xX][0-9a-fA-F]+")) {
            string Data1 = "";
            while (Data.Length > 0)
            {
                Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Data.Substring(0, 2), 16)).ToString();
                inData = inData + Data1;
                Data = Data.Substring(2, Data.Length - 2);
            }
        }
        return inData;
    }
