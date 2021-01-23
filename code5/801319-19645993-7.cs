    public static class MarshalHelper
    {
        public unsafe static T Read<T>(IntPtr address)
        {
            object value;
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Int16:
                    value = *(short*)address;
                    break;
                case TypeCode.Int32:
                    value = *(int*)address;
                    break;
                case TypeCode.Int64:
                    value = *(long*)address;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return (T)value;
        }
    }
