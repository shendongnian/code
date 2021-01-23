    public sealed class TypedToTypelessCollectionConverter : JsonConverter
    {
        [ThreadStatic]
        static Type itemType;
        public static IDisposable SetItemType(Type deserializedType)
        {
            return new ItemType(deserializedType);
        }
        sealed class ItemType : IDisposable
        {
            Type oldType;
            internal ItemType(Type type)
            {
                this.oldType = itemType;
                itemType = type;
            }
            int disposed = 0;
            public void Dispose()
            {
                // Dispose of unmanaged resources.
                if (Interlocked.Exchange(ref disposed, 1) == 0)
                {
                    // Free any other managed objects here.
                    itemType = oldType;
                    oldType = null;
                }
                // Suppress finalization.  Since this class actually has no finalizer, this does nothing.
                GC.SuppressFinalize(this);
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ICollection);
        }
        public override bool CanWrite { get { return false; }}
        public override bool CanRead { get { return itemType != null; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(List<>).MakeGenericType(itemType));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class TypeExtensions
    {
        /// <summary>
        /// Return all interfaces implemented by the incoming type as well as the type itself if it is an interface.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }
        public static IEnumerable<Type> GetEnumerableTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    yield return intType.GetGenericArguments()[0];
                }
            }
        }
    }
