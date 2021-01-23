      static void PrintBufferAsInt(byte[] buffer)
      {
         for(int i = 0; i < buffer.Length; i+=4)
         {
            var value = BitConverter.ToInt32(buffer, i);
            Console.WriteLine(value);
         }
      }
      static void Main(string[] args)
      {
         var buffer = new byte[] {1, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0};
         PrintBufferAsInt(buffer);
      }
