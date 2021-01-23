    public class DataTypes
    {
        private static readonly IReadOnlyDictionary<string, Func<IEnumerable<byte>, int, object>> Converters;
        
        static DataTypes()
        {
            Converters =
                new ReadOnlyDictionary<string, Func<IEnumerable<byte>, int, object>>(
                    new Dictionary<string, Func<IEnumerable<byte>, int, object>>
                    {
                        { "System.UInt16", (value, startIndex) => BitConverter.ToUInt16(value.ToArray(), startIndex) },
                        { "System.UInt32", (value, startIndex) => BitConverter.ToUInt32(value.ToArray(), startIndex) },
                        { "System.Int16", (value, startIndex) => BitConverter.ToInt16(value.ToArray(), startIndex) },
                        { "System.Int32", (value, startIndex) => BitConverter.ToInt32(value.ToArray(), startIndex) }
                    });
        }
        
        public object GetValue(string type, byte[] value, int startIndex)
        {
            if (!Converters.ContainsKey(type))
            {
                throw new ArgumentOutOfRangeException("type");
            }
            
            return Converters[type](value, startIndex);
        }
    }
