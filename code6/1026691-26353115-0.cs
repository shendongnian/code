        static void attributecheck()
        {
            var props = typeof(Product).GetProperties();
            foreach (var propertyInfo in props)
            {
                var att = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (att.Length >0)
                {
                }
            }
        }
