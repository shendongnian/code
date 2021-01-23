    **ApiDefinition.cs**
        [BaseType (typeof (NSObject))]
        public partial interface MarshalTest {
            [Export ("getMarshals:")]
            [Internal]
            int GetMarshals (ref IntPtr getMarshals);
        }
    **Extra.cs**
        public partial class MarshalTest : NSObject {
            public unsafe Marshal3D [] GetMarshals () {
                var ptr = IntPtr.Zero;
                var count = this.StoredNumber ();
                var array = new Marshal3D [count];
                GetMarshals (ref ptr);
                unsafe {
                    Marshal3D* ptr3d = (Marshal3D *) ptr;
                    for (int i = 0; i < count; i++)
                        array [i] = *ptr3d++;
                }
                return array;            
            }
        }
