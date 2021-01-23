    while (reader.Read())
    {
       if (reader.NodeType == XmlNodeType.Element)
       {
          sb.Append(reader.Name);
          while (reader.Read())
          {
             if (reader.HasValue)
             {               
                 sb.Append(":");
                 sb.Append(reader.Value);
                 sb.Append("<br/>");
             }
          }
       }
    }
