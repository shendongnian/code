    string[] item_name = { "abc", "def", "ghi" };
    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("textfile.txt"))
    {
        foreach(string name in item_name)
        {
            writer.Write(name);
        }
    }
