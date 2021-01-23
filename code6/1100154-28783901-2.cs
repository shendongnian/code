    public static class ItemExtensions
    {
            public static string Name(this Items val)
            {
                return Enum.GetName(val.GetType(), val);
            }
    
            public static UnitTypes Units(this Items val)
            {
                UnitTypes units = UnitTypes.Item;
                FieldInfo fi = val.GetType().GetField(val.ToString());
                UnitAttribute[] attrs =
                fi.GetCustomAttributes(typeof(UnitAttribute),
                                       false) as UnitAttribute[];
                if (attrs.Length > 0)
                {
                    units = attrs[0].Units;
                }
                return units;
            }
    
            public static CategoryType Section(this Items val)
            {
                // same sort of thing as above
            }
    
    }
