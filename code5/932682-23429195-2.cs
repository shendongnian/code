    string prefixText = context.Request.QueryString["term"];
    
    ....
    sb.Append("[");
    while (sdr.Read())
    {
        string u = sdr["FirstName"].ToString() + " " + sdr["LastName"].ToString();
        if (sb.Length > 1)
           sb.Append(",");
        sb.AppendFormat("{{\"id\":\"{0}\",\"label\":\"{0}\",\"value\":\"{0}\"}}", u); 
    }
    sb.Append("]");
