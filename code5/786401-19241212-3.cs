    // This size is just for example purpose. Should be fine tuned
    StringBuilder buffer = new StringBuilder(1048576);
    while(reader.Read())
    {
        for (int j = 0; j < reader.FieldCount; j++)
        {
            buffer.Append(reader[j] + "|");
        }
        buffer.AppendLine();
        if(buffer.Length > 1048576 - 1024)
        {
            writer.Write(buffer.ToString());
            buffer.Length = 0;
        }
    }
    writer.Write(buffer.ToString());
