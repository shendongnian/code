    unsafe public struct DistributorEmail
    {
        public fixed char DistributorId[20];
        public fixed char EmailID[20];
        public DistributorEmail(string dId)
        {
            fixed (char* distId = DistributorId)
            {
                char[] chars = dId.ToCharArray();
                Marshal.Copy(chars, 0, new IntPtr(distId), chars.Length);
            }
        }
    }
