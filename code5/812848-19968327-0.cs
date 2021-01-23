    public interface IStreamEvents {
        void DataReceived(int count, IProvideData obj);
        void Error();
    }
    public interface IProvideArray {
        void ProvideData([In, Out] 
            MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1) byte[] buff);
    }
