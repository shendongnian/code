    public class ExtFieldToIHtmlElementConverter : TypeConverter<ExtendedField, IHtmlElement>
        {
            protected override IHtmlElement ConvertCore(ExtendedField source)
            {
                var obj = Activator.CreateInstance(Type.GetType(source.type)) as IHtmlElement;
                obj.label = source.prompt;
                obj.value = source.value;
                return obj;
            }
        }
