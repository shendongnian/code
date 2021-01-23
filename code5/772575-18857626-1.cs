    StringBuilder sb = new StringBuilder();
    for (Int32 r = Selection.r1; r <= Selection.r2; r++)
    {
        if (Rows[r].Visible)
        {
            if (!String.IsNullOrEmpty(sb.ToString()))
                sb.Append(Environment.NewLine);
            for (Int32 c = Selection.c1; c <= Selection.c2; c++)
            {
                if (!sb.ToString().EndsWith(Environment.NewLine) &&
                    !String.IsNullOrEmpty(sb.ToString()) &&
                    !sb.ToString().EndsWith("\t"))
                    sb.Append("\t");
                if (String.IsNullOrEmpty(this[r, c] as String))
                    sb.Append(" ");
                else
                    sb.Append(this[r, c].ToString());
            }
        }
    }
    
    if (sb.Length > 0)
        ClipboardEx.SetTextThreadSafe(sb.ToString());
