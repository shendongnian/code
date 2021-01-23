    public class CustomKeyPropertyResolver : DommelMapper.IKeyPropertyResolver
    {
        public PropertyInfo ResolveKeyProperty(Type type)
        {
            return type.GetProperties().Single(p => p.Name.ToLower() == "id");
        }
    }
