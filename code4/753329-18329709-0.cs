    for (i = 0; i < col_no; i++)
    {
        Q.Append("'");
        Q.Append(col_value[i]);
        Q.Append("'");
        Q.Append(",");
    } 
    if(col_no > 0) Q.Length --; // <-- this removes the last character
    Q.Append(")");
    string query = Q.ToString();
