    public static class Extensions
    {
        public static FieldAttr GetFieldAttr(
            this TestObject source,
            Expression<Func<TestObject,object>> field)
        {
            var member = field.Body as MemberExpression;
            if (member == null) return null; // or throw exception
            var fieldName = member.Member.Name;
            var test = typeof (TestObject);
            var fieldType = test.GetField(fieldName);
            if (fieldType != null)
            {
                var attribute = fieldType.GetCustomAttribute<FieldAttr>();
                return attribute;
            }
            return null;
        }
    }
