    public unsafe struct DEVICE_Sub_State_Item
    {
        public fixed byte err_text[50];
        public UInt32 state;
        public fixed byte obj_name[50];
        public fixed byte name[50];
        public string ErrorText
        {
            get
            {
                byte[] buffer = new byte[50];
                fixed (byte* b = err_text)
                    Marshal.Copy(new IntPtr(b), buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer);
            }
        }
    }
