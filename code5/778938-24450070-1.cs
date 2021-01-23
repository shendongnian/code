    private static void DumpProperties(Properties props)
    {
        foreach (Property p in props)
        {
            object val = null;
            try
            {
                val = (object)p.Value;
            }
            catch (Exception e)
            {
                val = e.Message;
            }
            Debug.WriteLine(
                "{0} ({2}) = {1}", 
                p.Name, 
                val, 
                (DataTypeEnum) p.Type);
        }
    }
