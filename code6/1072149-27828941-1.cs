    public static class ModConverter
    {
        public static string ToModStampString(byte[] modStamp)
        {
            return BitConverter.ToString(modStamp);
        }
    }
    public partial class Company
    {
        public string ModStampString 
        {
            get
            {
                return ModConverter.ToModStampString(this.ModStamp);
            }
        }
    }
