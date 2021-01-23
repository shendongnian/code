    public static T PopulateLookupEntity<T>(this T entity, object[] rowItems,
        bool noDescription = false) where T : BaseLookupEntity
    {
        int id = 0;
        int.TryParse(rowItems[0].ToString(), out id);
        entity.RecordID = id;
        var attributesFirstIndex = 1;
        if (!noDescription)
        {
            entity.Description = rowItems[1].ToString();
            attributesFirstIndex = 2;
        }
        entity.Attributes = new object[rowItems.Length - attributesFirstIndex];
        for (int index = attributesFirstIndex; index < rowItems.Length; index++)
        {
            entity.Attributes[index - attributesFirstIndex] = rowItems[index];
        }
        return (T)entity;
    }
