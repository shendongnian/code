    public interface iProcessingInformation
    {
        [DispId(2)]
        object[] Accounts
        {
            [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] get;
            set;
        }
    }
    public class ProcessingInformation : iProcessingInformation
    {
        public object[] Accounts
        {
            get
            {
                return new object[] { new AccountInformation() };
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
