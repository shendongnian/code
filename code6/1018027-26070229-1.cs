    public class Program
    {
        static void Main()
        {
            decimal[] ds = { 193.45m, 245.00m };
            foreach (decimal d in ds)
            {
                Console.WriteLine(Format8(d));
            }
        }
        static string Format8(decimal d)
        {
            int[] parts = decimal.GetBits(d);
            bool sign = (parts[3] & 0x80000000) != 0;
            byte scale = (byte)((parts[3] >> 16) & 0x7F);
            Debug.Assert(scale == 2);
            scale = 0; // alter scale to remove the point
            return new decimal(parts[0], parts[1], parts[2], sign, scale)
                .ToString("00000000");
        }
    }
