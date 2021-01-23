    using System.Drawing.Imaging;
    namespace TestProject2
    {
    public abstract class BGRBase
    {
        //init to your bitmap's BitmapData, obtained by calling Bitmap.LockBits
        protected readonly BitmapData data;
        public abstract void SetRow(int rowIndex, byte b, byte g, byte r);
    }
    public class BGR3 : BGRBase
    {
        //use constructor to ensure that the bitmap's width is compatible
        public unsafe override void SetRow(int rowIndex, byte b, byte g, byte r)
        {
            byte* row = (byte*)data.Scan0 + rowIndex * data.Stride;
            row[0] = row[3] = row[6] = b;
            //etc
        }
    }
    public class BGR5 : BGRBase
    {
        public override unsafe void SetRow(int rowIndex, byte b, byte g, byte r)
        {
            //code as adove
        }
    }
    }
