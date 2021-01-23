    ResXResourceWriter rsxw = new ResXResourceWriter(path);
    bool added = false;
    if (File.Exists(path))
    {
        ResXResourceReader reader = new ResXResourceReader(path);
        foreach (DictionaryEntry node in reader)
        {
            if (key == node.Key.ToString())
            {
                 rsxw.AddResource(key, value);
                 added = true;
            }
            else rsxw.AddResource(node.Key.ToString(), node.Value);
        }
    }
    if(!added) rsxw.AddResource(key, value);
    rsxw.Close();
