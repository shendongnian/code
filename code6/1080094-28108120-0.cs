    var sb = new StringBuilder();
    foreach (var prop in item.GetType().GetProperties())
    {
        sb.Append("Type: ");
        sb.Append(prop.Name);
        sb.Append("\tValue:");
        var value = prop.GetValue(item);
        if (value == null)
        {
            sb.Append(" NULL");
        }
        else
        {
            sb.Append(" [");
            sb.Append(value);
            sb.Append("]");
        }
        sb.Append(Environment.NewLine);
    }
    Console.WriteLine(sb.ToString());
