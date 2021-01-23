    using System.Runtime.InteropServices;
    
    namespace Foo {
        
        public enum E1 : byte
        {
            A,
            B,
            C
        }
        
        public enum E2 : byte
        {
            D,
            E,
            F
        }
        
        
        [StructLayout(LayoutKind.Sequential,Pack=4)]
        public struct SomeStruct
        {
            public int  _var1; //4 byte
            public byte     _var2; //1 byte(because Pack is 4 this will take 4 byte)
            public byte     _var3; //1 byte(because Pack is 4 this will take 4 byte) 
            public ulong _var4; //8 byte
            
            public SomeStruct (int var1, byte var2, byte var3, ulong var4) {
                 this._var1 = var1;
                 this._var2 = var2;
                 this._var3 = var3;
                 this._var4 = var4;
            }
            
        }
    
    }
    
    Foo.SomeStruct i = new Foo.SomeStruct(1302,5,17,1425);
    Marshal.SizeOf( typeof( Foo.SomeStruct ) );
    sizeof(Foo.SomeStruct);
    int size = sizeof(Foo.SomeStruct);
    byte[] result = new byte[size];
    IntPtr buffer = Marshal.AllocHGlobal(size);
    Marshal.StructureToPtr(i, buffer, false);
    Marshal.Copy(buffer, result, 0, size);
