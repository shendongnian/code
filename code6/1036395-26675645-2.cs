    public bool Equals(object x, object y, int depth)
        {
            var xType = x.GetType();
            var yType = y.GetType();
            if (xType != yType) return false;
            
            return GetPropertiesWithoutKey(xType).All(pd => ConexioComparer.IsPropertyChanged(pd, x, y, ++depth));
        }
