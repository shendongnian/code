        /// <summary>
        /// If the first property has no attribute, sort it first
        /// If the second property has no attribute, sort it first
        /// Compare the Order properties of both attributes
        /// </summary>
        private class PropertyInfoComparer : IComparer<PropertyInfo>
        {
            public int Compare(PropertyInfo x, PropertyInfo y)
            {
                if (x == y) return 0;
                var attrX = (DisplayAttribute)x.GetCustomAttributes(typeof(DisplayAttribute)).FirstOrDefault();
                int? orderX = attrX?.GetOrder();
                if (orderX == null) return -1;
                var attrY = (DisplayAttribute)y.GetCustomAttributes(typeof(DisplayAttribute)).FirstOrDefault();
                int? orderY = attrY?.GetOrder();
                if (orderY == null) return 1;
                return ((int)orderX).CompareTo((int)orderY);
            }
        }
