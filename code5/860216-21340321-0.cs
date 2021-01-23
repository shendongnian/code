    [EntityFields("field1","field2")]
    public class BaseEntity 
    {
        public ISet<string> Fields
        {
            get
            {
                Type typeToCheck = GetType();
                ISet<string> fields = new HashSet<string>();
                do
                {
                    var entityFieldsAttribute =
                        (EntityFields) Attribute.GetCustomAttribute(typeToCheck, typeof (EntityFields));
                    if (entityFieldsAttribute != null)
                    {
                        fields.UnionWith(entityFieldsAttribute.Fields);
                    }
                    typeToCheck = typeToCheck.BaseType;
                } while (typeToCheck != typeof (BaseEntity));
                return fields;
            }
        }
    }
    [EntityFields("field3","field4")]
    public class ChildEntity:BaseEntity 
    {
        
    }
