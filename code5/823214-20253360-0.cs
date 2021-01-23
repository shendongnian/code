    IDbCommand cmd = proxy.Connection.CreateCommand();
    try
    {
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(proxy.Connection.CreateParameter(cmd, "@dealershipId", dealershipId));
       cmd.Parameters.Add(proxy.Connection.CreateParameter(cmd, "@pluginId", pluginId));
       PluginInfo[] pluginInfos = PopulatePluginsFromCommand(cmd);
       result = pluginInfos.First();}
    finally
    {
        if(cmd != null)
        {
            ((IDisposable)cmd).Dispose();
        }
    }
