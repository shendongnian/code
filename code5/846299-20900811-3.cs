    string[] item_name = { "abc", "def", "ghi" };
    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("textfile.txt"))
    {
        item_name.ToList().ForEach(i =>
        {
            writer.Write(i);
        });
    }
