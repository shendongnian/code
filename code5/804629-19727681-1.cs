    AddParamsToCommand(SqlCommand cmd, Dictionary<string,string> paramList)
    {
        foreach (string s in paramList.Keys)
        {
            sqlParameter p = cmd.CreateParameter();
            p.Name = s;
            p.Value = paramList[s];
            cmd.Parameters.Add(p);
        }
    }
