    if (e.Exception.InnerException != null)
    {
        sb.AppendLine("InnerException");
        if (e.Exception.InnerException.Message == null)
        {
            sb.AppendLine("e.Exception.InnerException.Message == null");
        }
        else
        {
            sb.AppendLine("e.Exception.InnerException.Message = " + e.Exception.InnerException.Message);
        }
        if (!string.IsNullOrEmpty(e.Exception.InnerException.StackTrace))
        {
            sb.AppendLine("e.Exception.InnerException.StackTrace ");
            int count = 0;
            foreach (string line in e.Exception.InnerException.StackTrace.Split('\n'))
            {
                sb.AppendLine(line.Trim());
                count++;
                if (count > 10) break;
            }
        }
    }
    sb.AppendLine("OuterException");
    if (e.Exception.Message == null)
    {
        sb.AppendLine("e.Exception.Message == null");
    }
    else
    {
        sb.AppendLine("e.Exception.Message = " + e.Exception.Message);
    }
    if (!string.IsNullOrEmpty(e.Exception.StackTrace))
    {
        sb.AppendLine("e.Exception.StackTrace ");
        int count = 0;
        foreach (string line in e.Exception.StackTrace.Split('\n'))
        {
            sb.AppendLine(line.Trim());
            count++;
            if (count > 10) break;
        }
    }
