    foreach (ModelName s in m)
      {
          sb.Append(s.FName.Replace("\n",""));
          sb.Append(",");
          sb.Append(s.SName.Replace("\n",""));
          sb.Append(","); /* I doubt you want this one */
          sb.AppendLine();
      }
