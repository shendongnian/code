    static void Main(string[] args)
    {
        string yafs = "Looking for LOVE in all the wrong love places...";
        string searchTerm = "LOVE";
        Console.Write(ReplaceInsensitive(yafs, searchTerm));
        Console.Read();
    }
    private static string ReplaceInsensitive(string yafs, string searchTerm)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string word in yafs.Split(' '))
       {
            string tempStr = word;
            if (word.ToUpper() == searchTerm.ToUpper())
            {
                tempStr = word.Insert(0, "<span style='background-color: #FFFF00'>");
                int len = tempStr.Length;
                tempStr = tempStr.Insert(len, "</span>");
            }
            sb.AppendFormat("{0} ", tempStr);
        }
        return sb.ToString();
    }
