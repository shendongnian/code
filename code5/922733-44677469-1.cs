    /// <summary>
    /// Returns NullSurrogate for all types not marked Serializable
    /// </summary>
    public class NonSerializableSurrogateSelector : ISurrogateSelector
    {
        public void ChainSelector(ISurrogateSelector selector)
        {
            throw new NotImplementedException();
        }
        public ISurrogateSelector GetNextSelector()
        {
            throw new NotImplementedException();
        }
        public ISerializationSurrogate GetSurrogate(
          Type type, StreamingContext context, out ISurrogateSelector selector)
        {
            if (!type.IsSerializable)
            {
                //type not marked Serializable
                selector = this;
                return new NullSurrogate();
            }
            // use default surrogate
            selector = null;
            return null;
        }
    }
    public class NullSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
        }
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context,
                                    ISurrogateSelector selector)
        {
            return null;
        }
    }
    public class IgnoreUnknownTypesBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            try
            {
                var assembly = Assembly.Load(assemblyName);
                var type = assembly.GetType(typeName);
                return type;
            }
            catch
            {
                return typeof(IgnoreUnknownTypesBinder); // here could be any non-serializable class
            }
        }
    }
