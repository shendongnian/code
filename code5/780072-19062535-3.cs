    static void Main(string[] args)
    {
        char[] trimchar = {','};
        string str = "name1, name2,2 ,name3";
        var result = str.Split();
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = result[i].Trim(trimchar);
        }
           
        string[] strArray = { "name1", "name2,2", "name3" };
    }
