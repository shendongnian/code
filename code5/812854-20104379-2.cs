    public void SendData(object data) {
        byte[] buf = FPHelper.ToSZArray(data);
        // Use buf here
    }
    public class FPHelper {
        public static byte[] ToSZArray(object param) {
            var array = param as Array;
            if (array == null)
                throw new ArgumentException("Expected a binary array, (did you use CREATEBINARY()?)");
            if (array.Rank != 1)
                throw new ArgumentException("Expected array with rank 1.", "param");
            var dest = new byte[array.Length];
            Buffer.BlockCopy(array, 0, dest, 0, array.Length);
            return dest;
        }
    }
