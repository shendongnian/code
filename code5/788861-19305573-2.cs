    StringBuilder str = new StringBuilder();
    foreach (var entry in products)
    {
       str.AppendLine(string.Format("{0}:{1}", entry.Key, entry.Value));
    }
    File.WriteAllText(fileName, str.ToString()); }
