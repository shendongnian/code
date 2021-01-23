    public static class GenericCopier
    {
        public static T DeepCopy<T>(T objectToCopy)
        {
            var selector = new SurrogateSelector();
            var imageSurrogate = new BitmapImageCloneSurrogate();
            imageSurrogate.Register(selector);
            BinaryFormatter binaryFormatter = new BinaryFormatter(selector, new StreamingContext(StreamingContextStates.Clone));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, objectToCopy);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
    class CloneWrapper<T> : IObjectReference
    {
        public T Clone { get; set; }
        #region IObjectReference Members
        object IObjectReference.GetRealObject(StreamingContext context)
        {
            return Clone;
        }
        #endregion
    }
    public abstract class CloneSurrogate<T> : ISerializationSurrogate where T : class
    {
        readonly Dictionary<T, long> OriginalToId = new Dictionary<T, long>();
        readonly Dictionary<long, T> IdToClone = new Dictionary<long, T>();
        public void Register(SurrogateSelector selector)
        {
            foreach (var type in Types)
                selector.AddSurrogate(type, new StreamingContext(StreamingContextStates.Clone), this);
        }
        IEnumerable<Type> Types
        {
            get
            {
                yield return typeof(T);
                yield return typeof(CloneWrapper<T>);
            }
        }
        protected abstract T Clone(T original);
        #region ISerializationSurrogate Members
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var original = (T)obj;
            long cloneId;
            if (original == null)
            {
                cloneId = -1;
            }
            else
            {
                if (!OriginalToId.TryGetValue(original, out cloneId))
                {
                    Debug.Assert(OriginalToId.Count == IdToClone.Count);
                    cloneId = OriginalToId.Count;
                    OriginalToId[original] = cloneId;
                    IdToClone[cloneId] = Clone(original);
                }
            }
            info.AddValue("cloneId", cloneId);
            info.SetType(typeof(CloneWrapper<T>));
        }
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var wrapper = (CloneWrapper<T>)obj;
            var cloneId = info.GetInt64("cloneId");
            if (cloneId != -1)
                wrapper.Clone = IdToClone[cloneId];
            return wrapper;
        }
        #endregion
    }
    public sealed class BitmapImageCloneSurrogate : CloneSurrogate<BitmapImage>
    {
        protected override BitmapImage Clone(BitmapImage original)
        {
            return original == null ? null : original.Clone();
        }
    }
