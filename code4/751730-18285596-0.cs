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
            var par1 = Expression.Parameter(typeof(BinaryReader));
            Type type = typeof(T);
            MethodInfo mi;
            // The use of Method<T> is just to extract the MethodInfo without using strings like "ReadBoolean"
            if (type == typeof(bool))
            {
                mi = Method<Func<BinaryReader, bool>>(p => p.ReadBoolean());
            }
            else if (type == typeof(char))
            {
                mi = Method<Func<BinaryReader, char>>(p => p.ReadChar());
            }
            else if (type == typeof(string))
            {
                mi = Method<Func<BinaryReader, string>>(p => p.ReadString());
            }
            else if (type == typeof(sbyte))
            {
                mi = Method<Func<BinaryReader, sbyte>>(p => p.ReadSByte());
            }
            else if (type == typeof(short))
            {
                mi = Method<Func<BinaryReader, short>>(p => p.ReadInt16());
            }
            else if (type == typeof(int))
            {
                mi = Method<Func<BinaryReader, int>>(p => p.ReadInt32());
            }
            else if (type == typeof(long))
            {
                mi = Method<Func<BinaryReader, long>>(p => p.ReadInt64());
            }
            else if (type == typeof(byte))
            {
                mi = Method<Func<BinaryReader, byte>>(p => p.ReadByte());
            }
            else if (type == typeof(ushort))
            {
                mi = Method<Func<BinaryReader, ushort>>(p => p.ReadUInt16());
            }
            else if (type == typeof(uint))
            {
                mi = Method<Func<BinaryReader, uint>>(p => p.ReadUInt32());
            }
            else if (type == typeof(ulong))
            {
                mi = Method<Func<BinaryReader, ulong>>(p => p.ReadUInt64());
            }
            else if (type == typeof(float))
            {
                mi = Method<Func<BinaryReader, float>>(p => p.ReadSingle());
            }
            else if (type == typeof(double))
            {
                mi = Method<Func<BinaryReader, double>>(p => p.ReadDouble());
            }
            else if (type == typeof(decimal))
            {
                mi = Method<Func<BinaryReader, decimal>>(p => p.ReadDecimal());
            }
            else
            {
                throw new ArgumentException();
            }
            var read = Expression.Call(par1, mi);
            Read = Expression.Lambda<Func<BinaryReader, T>>(read, par1).Compile();
        }
        private static MethodInfo Method<Delegate>(Expression<Delegate> exp)
        {
            var call = (MethodCallExpression)exp.Body;
            return call.Method;
        }
    }
