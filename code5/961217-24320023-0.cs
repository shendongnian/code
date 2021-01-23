    using System;
    using System.IO;
    using System.Linq;
    
    public class Foo 
    {
        public UInt32 One { get; set; }
        public UInt32 Two { get; set; }
        public UInt32 Three { get; set; }
        public UInt32 Four { get; set; }
    
        public Foo() {}
    
        public Foo(byte[] array)
        {
            One = BitConverter.ToUInt32(array,0);    
            Two = BitConverter.ToUInt32(array,4);
            Three = BitConverter.ToUInt32(array,8);    
            Four = BitConverter.ToUInt32(array,12);    
        }
        public byte[] toByteArray()
        {
            byte[] retVal =  new byte[16];
            byte[] b = BitConverter.GetBytes(One);
            Array.Copy(b, 0, retVal, 0, 4);
            b = BitConverter.GetBytes(Two);
            Array.Copy(b, 0, retVal, 4, 4);
             b = BitConverter.GetBytes(Three);
            Array.Copy(b, 0, retVal, 8, 4);
             b = BitConverter.GetBytes(Four);
            Array.Copy(b, 0, retVal, 12, 4);
            return retVal;
        }
    }
    public class P{
        public static void Main(string[] args) {
            Foo foo = new Foo();
            foo.One = 1;
            foo.Two = 2;
            foo.Three = 3;
            foo.Four = 4;
            
            byte[] arr  = foo.toByteArray();
            Console.WriteLine(arr.Length);
            
            Foo bar = new Foo(arr);
            Console.WriteLine(string.Format("{0} {1} {2} {3}", bar.One, bar.Two, bar.Three, bar.Four));
        }
    }
