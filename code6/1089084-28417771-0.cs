    public string SerializeProjectKeys(List<ProjectKey> pks)
    {
        JObject toSerialize = new JObject();
        
        foreach (ProjectKey pk in pks)
        {
            string[] keyParts = pk.Key.Split('.');
            JObject currentObj = toSerialize;
            
            for (int i = 0; i < keyParts.Length; i++)
            {
                string keyPart = keyParts[i];
                
                if (i == keyParts.Length - 1)
                {
                    if (pk.Parent)
                    {
                        currentObj.Add(keyPart, new JObject());
                    }
                    else 
                    {
                        currentObj.Add(keyPart, string.Empty);
                    }
                }
                else 
                {
                    currentObj = (JObject)currentObj[keyPart];
                }
            }
        }
        
        return toSerialize.ToString();
    }
