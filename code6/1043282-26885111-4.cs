    internal class Program {
        public unsafe static int GetInfo(IntPtr t,UIntPtr size) {
            if(size.ToUInt32( ) == 4)
                Console.WriteLine( *( int* )t.ToPointer( ) );
            else //Is it our string?
                Console.WriteLine( new string( ( char* )t.ToPointer( ) ) );
            return 1;
        }
        public static unsafe int ManagedGetInfo<T>(T t) {
            if (t.GetType().IsEnum) {
                var handle = GCHandle.Alloc( t.GetType( ).GetField( "value__" ).GetValue( t ), GCHandleType.Pinned );
                var result = GetInfo( handle.AddrOfPinnedObject( ), new UIntPtr( (uint)Marshal.SizeOf( t.GetType().GetEnumUnderlyingType() ) ) );
                handle.Free( );
                return result;
            }
            else if (t.GetType().IsValueType) {
                var handle = GCHandle.Alloc( t, GCHandleType.Pinned );
                var result = GetInfo( handle.AddrOfPinnedObject( ), new UIntPtr( ( uint )Marshal.SizeOf( t ) ) );
                handle.Free( );
                return result;
            }
            else if (t is string) {
                var str = t as string;
                var arr = ( str + "\0" ).ToArray( );
                fixed (char *ptr = &arr[0])
                {
                    return GetInfo( new IntPtr( ptr ), new UIntPtr( ( uint )( arr.Length * Marshal.SizeOf( typeof(char) ) ) ) );
                }
            }
            return -1;
        }
        enum A {
           x,y,z
        }
        private static void Main( ) {
            string str = "1234";
            int i = 1234;
            A a = A.y;
            Console.WriteLine( "Should print: " + str );
            ManagedGetInfo( str );
            Console.WriteLine( "Should print: " + i );
            ManagedGetInfo( i );
            Console.WriteLine( "Should print: " + ( int )a );
            ManagedGetInfo( a );
        }
    }
