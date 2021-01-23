    public unsafe struct Buffer
    {
        const int Size=100;
        fixed byte data[Size];
        public void Clear()
        {
            fixed(byte* ptr=data)
            {
                // Fill values with 0
                for(int i=0; i<Size; i++)
                {
                    ptr[i]=0;
                }
            }
        }
        public void Store(byte[] array, int index)
        {
            fixed(byte* ptr=data)
            {
                // find max elements remaining
                int N=Math.Min(index + array.Length, Size) - index;
                // Fill values from input bytes
                for(int i=0; i<N; i++)
                {
                    ptr[index+i]=array[i];
                }
            }
        }
        public byte[] ToArray()
        {
            byte[] array=new byte[Size];
            fixed(byte* ptr=data)
            {
                // Extract all data
                for(int i=0; i<Size; i++)
                {
                    array[i]=ptr[i];
                }
            }
            return array;
        }
    }
    unsafe class Program
    {
        static void Main(string[] args)
        {
            Buffer buffer=new Buffer();
            // buffer contains 100 bytes
            int size=sizeof(Buffer);
            // size = 100
            buffer.Clear();
            // data = { 0, 0, 0, ... }
            buffer.Store(new byte[] { 128, 207, 16, 34 }, 0);
            byte[] data=buffer.ToArray();
            // { 128, 207, 16, 34, 0, 0, ... }
        }
    }
