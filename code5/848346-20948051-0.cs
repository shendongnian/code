    public class UnattributedTypeSurrogate : ISerializationSurrogate
    {
        private const BindingFlags publicOrNonPublicInstanceFields =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        public void GetObjectData(object obj,
            SerializationInfo info, StreamingContext context)
        {
            var type = obj.GetType();
            foreach (var field in type.GetFields(publicOrNonPublicInstanceFields))
            {
                var fieldValue = field.GetValue(obj);
                var fieldValueIsNull = fieldValue != null;
                if (fieldValueIsNull)
                {
                    var fieldValueRuntimeType = fieldValue.GetType();
                    info.AddValue(field.Name + "RuntimeType",
                        fieldValueRuntimeType.AssemblyQualifiedName);
                }
                info.AddValue(field.Name + "ValueIsNull", fieldValueIsNull);
                info.AddValue(field.Name, fieldValue);
            }
        }
        public object SetObjectData(object obj,
            SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var type = obj.GetType();
            foreach (var field in type.GetFields(publicOrNonPublicInstanceFields))
            {
                var fieldValueIsSerializable = info.GetBoolean(field.Name + "ValueIsNull");
                if (fieldValueIsSerializable)
                {
                    var fieldValueRuntimeType = info.GetString(field.Name + "RuntimeType");
                    field.SetValue(obj,
                        info.GetValue(field.Name, Type.GetType(fieldValueRuntimeType)));
                }
            }
            return obj;
        }
    }
    public class UnattributedTypeSurrogateSelector : ISurrogateSelector
    {
        private readonly SurrogateSelector innerSelector = new SurrogateSelector();
        private readonly Type iFormatter = typeof(IFormatter);
        public void ChainSelector(ISurrogateSelector selector)
        {
            innerSelector.ChainSelector(selector);
        }
        public ISerializationSurrogate GetSurrogate(
            Type type, StreamingContext context, out ISurrogateSelector selector)
        {
            if (!type.IsSerializable)
            {
                selector = this;
                return new UnattributedTypeSurrogate();
            }
            return innerSelector.GetSurrogate(type, context, out selector);
        }
        public ISurrogateSelector GetNextSelector()
        {
            return innerSelector.GetNextSelector();
        }
    }
