    public static class Extensions
    {
        public static FieldAttr GetFieldAttr(this object source)
        {
            var test = typeof (TestObject);
            var type = test.GetFields()
                .FirstOrDefault(x => x.FieldType == source.GetType());
            if (type != null)
            {
                var attribute = type.GetCustomAttribute<FieldAttr>();
                return attribute;
            }
            return null;
        }
    }
