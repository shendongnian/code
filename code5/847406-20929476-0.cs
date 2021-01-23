    public static string NextImageName(string filename, int newNumber)
    {
        int i = 0;
        foreach (char c in filename)  // get index of first number
        {
            if (char.IsNumber(c))
                break;
            else
                i++;
        }
        string s = filename.Substring(0,i);  // remove original number
        s = s + newNumber.ToString();        // add new number
        return s;
    }
