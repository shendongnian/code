    using(System.IO.StreamWriter writer = new System.IO.StreamWriter(path)
    {
        foreach(string item in OrderItems.Items)
        {
            writer.write(item);
        }
    }
