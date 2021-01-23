    public class CustomTypeResolver : JavaScriptTypeResolver
    {
        public override Type ResolveType(string id)
        {
            return id == "class1" ? typeof(Class1) : typeof(Class2);
        }
        public override string ResolveTypeId(Type type)
        {
            return type == typeof(Class1) ? "class1" : "class2";
        }
    }
