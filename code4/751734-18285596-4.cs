    public static class BinaryReaderEx
    {
        public static T Read<T>(this BinaryReader br)
        {
            return BinaryReader<T>.Read(br);
        }
    }
    public static class BinaryReader<T>
    {
        public static readonly Func<BinaryReader, T> Read;
        static BinaryReader()
        {
            Type type = typeof(T);
            if (type == typeof(bool))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, bool>)(p => p.ReadBoolean()));
            }
            else if (type == typeof(char))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, char>)(p => p.ReadChar()));
            }
            else if (type == typeof(string))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, string>)(p => p.ReadString()));
            }
            else if (type == typeof(sbyte))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, sbyte>)(p => p.ReadSByte()));
            }
            else if (type == typeof(short))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, short>)(p => p.ReadInt16()));
            }
            else if (type == typeof(int))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, int>)(p => p.ReadInt32()));
            }
            else if (type == typeof(long))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, long>)(p => p.ReadInt64()));
            }
            else if (type == typeof(byte))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, byte>)(p => p.ReadByte()));
            }
            else if (type == typeof(ushort))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, ushort>)(p => p.ReadUInt16()));
            }
            else if (type == typeof(uint))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, uint>)(p => p.ReadUInt32()));
            }
            else if (type == typeof(ulong))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, ulong>)(p => p.ReadUInt64()));
            }
            else if (type == typeof(float))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, float>)(p => p.ReadSingle()));
            }
            else if (type == typeof(double))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, double>)(p => p.ReadDouble()));
            }
            else if (type == typeof(decimal))
            {
                Read = (Func<BinaryReader, T>)(Delegate)((Func<BinaryReader, decimal>)(p => p.ReadDecimal()));
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
