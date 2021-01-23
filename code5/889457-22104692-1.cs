    public class FrameMarshaler : ICustomMarshaler
    {
    		public void CleanUpManagedData(object ManagedObj)
            {
            }
            public void CleanUpNativeData(IntPtr pNativeData)
            {
            }
            public int GetNativeDataSize()
            {
                return -1;
            }
            public IntPtr MarshalManagedToNative(object ManagedObj)
            {
                throw new NotImplementedException();
            }
            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
    			// Here, we call C++/CLI code
                FrameOfData frame = Marshaler.MarshalFrame(pNativeData);	
                return frame;
            }	
    }
