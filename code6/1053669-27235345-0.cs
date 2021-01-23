    [StructLayout(LayoutKind.Sequential)]
    public struct ModBusPacket
    {
        public UInt16 TransactionIdentifier;
        public UInt16 ProtocolIdentifier;
        public UInt16 Length;
        public byte UnitIdentifier;
        public byte FunctionCode;
        public byte[] Data;
        static int PostIncrement(ref int pos, int inc)
        {
            int old = pos;
            pos += inc;
            return old;
        }
        public ModBusPacket(byte[] buffer)
        {
            int pos = 0;
            TransactionIdentifier = (buffer.Length >= pos + 2 ? BitConverter.ToUInt16(buffer, PostIncrement(ref pos, 2)) : (UInt16)0);
            ProtocolIdentifier = (buffer.Length >= pos + 2 ? BitConverter.ToUInt16(buffer, PostIncrement(ref pos, 2)) : (UInt16)0);
            Length = (buffer.Length >= pos + 2 ? BitConverter.ToUInt16(buffer, PostIncrement(ref pos, 2)) : (UInt16)0);
            UnitIdentifier = (buffer.Length >= pos + 1 ? buffer[PostIncrement(ref pos, 1)] : (byte)0);
            FunctionCode = (buffer.Length >= pos + 1 ? buffer[PostIncrement(ref pos, 1)] : (byte)0);
            var length = Math.Max(buffer.Length - pos, 0);
            Data = new byte[length];
            if (length > 0)
                Array.Copy(buffer, pos, Data, 0, length);
        }
        public override string ToString()
        {
            return ModBusPacketExtensions.ToStringWithReflection(this);
        }
    }
    public static class ModBusPacketExtensions
    {
        public static string ToStringWithReflection<T>(this T obj)
        {
            if (obj == null)
                return string.Empty;
            var type = obj.GetType();
            var fields = type.GetFields();
            var properties = type.GetProperties();
            var values = new List<KeyValuePair<string, object>>();
            Array.ForEach(fields, (field) => values.Add(new KeyValuePair<string, object>(field.Name, field.GetValue(obj))));
            Array.ForEach(properties, (property) =>
            {
                if (property.CanRead)
                    values.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(obj, null)));
            });
            return values.Aggregate(new StringBuilder(), (sb, pair) => { if (sb.Length > 0) sb.Append(","); sb.Append(pair); return sb; }).ToString();
        }
        public static ModBusPacket ToPacket(this byte[] buffer)
        {
            return new ModBusPacket(buffer);
        }
    }
