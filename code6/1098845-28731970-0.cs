    public static string[] getStrands(string[] list, string sequence)
    {
        if (list == null) {
            return null;
        }
        List<string> temp = new List<string>();
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] != null) {
                string x = list[i];
                if (x.IndexOf(sequence) != -1)
                    temp.Add(x);
            }
        }
        //converts temp List into a string[] to return
        string[] result = new string[temp.Count];
        for (int i = 0; i < temp.Count; i++)
            result[i] = temp.ElementAt(i);
        return result;
    }
