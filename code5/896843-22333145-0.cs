    foreach (Type type in types)
    {
        if(!type.IsSubClassOf(typeof(NpcScript)) || type.IsAbstract)
        {
             continue;
        }
        if (!GameServer.NpcScripts.ContainsKey(shortname))
        {
            GameServer.NpcScripts.Add(shortname, type);
        }
    
        NpcScript myScript = (NpcScript)Activator.CreateInstance(type);
        //Do whatever with myScript
    }
