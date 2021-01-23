    var properties = typeof(customclass).GetProperties(BindingFlags.Public | 
                              BindingFlags.Instance).OrderBy(x => x.Name).ToList();
    
    List<customclass> BMrep = somefunction();
    var retdata = new object[BMrep.Count, properties.Count];
    
    for (int i = 0; i < BMrep.Count; i++)
    {
        for (int j = 0; j < properties.Count; j++)
        {
            retdata[i, j] = properties[j].GetValue(BMrep[i], null);
        }
    }
    return retdata;
