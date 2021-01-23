    public static T GetFreshItem<T>(T dirtyItem) where T:Item
    {
        string itemProperties = dirtyItem.InitialItemSettingsJSON;
        return JsonConvert.DeserializeObject<T>(itemProperties);
    }
    
