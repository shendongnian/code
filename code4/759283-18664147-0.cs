            //This must be thread static since, in theory, the marshaled
        //call could be executed simultaneously on two or more threads.
        [ThreadStatic] int[] marshaledObject;
        public IntPtr MarshalManagedToNative(object managedObj)
        {
            if (managedObj == null)
                return IntPtr.Zero;
            if (!(managedObj is int[]))
                throw new MarshalDirectiveException("VariableLengthArrayMarshaler must be used on an int array.");
            //This is called on the way in so we must keep a reference to 
            //the original object so we can marshal to it on the way out.
            marshaledObject = (int[])managedObj;
            int size = sizeof(int) + marshaledObject.Length * sizeof(int);
            IntPtr pNativeData = Marshal.AllocHGlobal(size);
            Marshal.WriteInt32(pNativeData, marshaledObject.Length);
            Marshal.Copy(marshaledObject, 0, (IntPtr)(pNativeData.ToInt64() + sizeof(int)), marshaledObject.Length);
            return pNativeData;
        }
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            if (marshaledObject == null)
                throw new MarshalDirectiveException("This marshaler can only be used for in-place ([In. Out]) marshaling.");
            int len = Marshal.ReadInt32(pNativeData);
            if (marshaledObject.Length != len)
                throw new MarshalDirectiveException("The size of the array cannot be changed when using in-place marshaling.");
            Marshal.Copy((IntPtr)(pNativeData.ToInt64() + sizeof(int)), marshaledObject, 0, len);
            return marshaledObject;
        }
