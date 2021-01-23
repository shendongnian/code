    [StructLayout(LayoutKind.Sequential)]
    public struct ModBusPacket
    {
        // http://en.wikipedia.org/wiki/Modbus#Frame_format
        // The byte order is Big-Endian (first byte contains MSB).
        public const bool IsLittleEndian = false;
        public UInt16 TransactionIdentifier;
        public UInt16 ProtocolIdentifier;
        public UInt16 Length;
        public byte UnitIdentifier;
        public byte FunctionCode;
        public byte[] Data;
        static int PostIncrement(ref int index, int inc)
        {
            int old = index;
            index += inc;
            return old;
        }
        static byte[] ElementArray(byte[] buffer, ref byte[] swapBuffer, ref int index, int size)
        {
            if (swapBuffer == null || swapBuffer.Length < size)
                Array.Resize(ref swapBuffer, size);
            Array.Copy(buffer, PostIncrement(ref index, size), swapBuffer, 0, size);
            if (BitConverter.IsLittleEndian != IsLittleEndian)
                Array.Reverse(swapBuffer);
            return swapBuffer;
        }
        public ModBusPacket(byte[] buffer)
        {
            int pos = 0;
            byte[] swapBuffer = null;
            TransactionIdentifier = (buffer.Length >= pos + 2 ? BitConverter.ToUInt16(ElementArray(buffer, ref swapBuffer, ref pos, 2), 0) : (UInt16)0);
            ProtocolIdentifier = (buffer.Length >= pos + 2 ? BitConverter.ToUInt16(ElementArray(buffer, ref swapBuffer, ref pos, 2), 0) : (UInt16)0);
            Length = (buffer.Length >= pos + 2 ? BitConverter.ToUInt16(ElementArray(buffer, ref swapBuffer, ref pos, 2), 0) : (UInt16)0);
            UnitIdentifier = (buffer.Length >= pos + 1 ? buffer[PostIncrement(ref pos, 1)] : (byte)0);
            FunctionCode = (buffer.Length >= pos + 1 ? buffer[PostIncrement(ref pos, 1)] : (byte)0);
            var length = Math.Max(buffer.Length - pos, 0);
            Data = new byte[length];
            if (length > 0)
                Array.Copy(buffer, pos, Data, 0, length);
        }
        public override string ToString()
        {
            return ObjectExtensions.ToStringWithReflection(this);
        }
    }
    public static class ObjectExtensions
    {
        public static string ToStringWithReflection<T>(this T obj)
        {
            if (obj == null)
                return string.Empty;
            var type = obj.GetType();
            var fields = type.GetFields();
            var properties = type.GetProperties().Where(p => p.GetIndexParameters().Length == 0 && p.GetGetMethod(true) != null);
            var values = new List<KeyValuePair<string, object>>();
            Array.ForEach(fields, (field) => values.Add(new KeyValuePair<string, object>(field.Name, field.GetValue(obj))));
            foreach (var property in properties)
                if (property.CanRead)
                    values.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(obj, null)));
            return values.Aggregate(new StringBuilder(), (s, pair) => (s.Length == 0 ? s.Append("{").Append(obj.GetType().Name).Append(": ") : s.Append("; ")).Append(pair)).Append("}").ToString();
        }
    }
