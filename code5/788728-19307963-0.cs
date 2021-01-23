        class mycomparer : System.Collections.Generic.IEqualityComparer<Item>
        {
            bool customcomparer = false;
            public mycomparer(bool custom = false) 
            {
                customcomparer = custom;
            }
            public bool Equals(Item type1, Item type2)
            {
                return GetHashCode(type1) == GetHashCode(type2);
            }
            public int GetHashCode(Item type)
            {
                if (customcomparer)
                    return string.Concat(type.Name, type.Type).ToLower().GetHashCode();
                return string.Concat(type.Name, type.Type, type.Switch).ToLower().GetHashCode();
            }
        }
