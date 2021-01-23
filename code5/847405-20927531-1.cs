    public static string NextImageName(string filename, int newNumber)
    {
        string oldnumber = "";
        foreach (var item in filename.ToCharArray().Reverse())
            if (char.IsDigit(item))
                oldnumber = item + oldnumber ;
            else
                break;
        return filename.Replace(oldnumber ,newNumber.ToString());
    }
