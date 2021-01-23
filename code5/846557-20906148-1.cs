    StringBuilder builder = new StringBuilder();
    using(System.IO.StreamWriter writer = new System.IO.StreamWriter(path)
    {
        foreach(string item in OrderItems.Items)
        {
            builder.append(string.format("{0}{1}", item, Environment.NewLine));
        }
        writer.write(builder.ToString());
    }
