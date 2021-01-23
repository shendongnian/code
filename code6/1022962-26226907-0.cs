    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct x
            {
                public byte y;
                public byte zType;
            }
            static unsafe void Main(string[] args)
            {
                  var myByteArray = new byte[4];
                  myByteArray[0] = 1;
                  myByteArray[1] = 2;
                  myByteArray[2] = 3;
                  myByteArray[3] = 4;
                  fixed (byte* ptr = myByteArray)
                  {
                      var myStruct = (x*)ptr;
                      //myStruct now contain 
                      //myStruct.y == 1
                      //myStruct.ztype == 2
                  }
            }
        }
    }
