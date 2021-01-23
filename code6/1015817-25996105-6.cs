        bool GetPropByName(AdvOnCall item, string column)
        {
           return (bool)item.GetType().GetProperty(column).GetValue(item, null);
        }
    
