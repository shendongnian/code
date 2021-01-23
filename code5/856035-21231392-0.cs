    List<string> userPropertyList = new List<string>();
    ActiveDirectorySchema currSchema = ActiveDirectorySchema.GetCurrentSchema();
    ActiveDirectorySchemaClass collection = currSchema.FindClass("user");
    ReadOnlyActiveDirectorySchemaPropertyCollection properties = collection.GetAllProperties();
    IEnumerator enumerator = properties.GetEnumerator();
    while (enumerator.MoveNext())
    {
        userPropertyList.Add(enumerator.Current.ToString());
    }
