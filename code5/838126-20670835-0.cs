    public class UsbHid
    {
    ...
        public UsbHid(string str)
        {
            ...
        }
        // replace virtual with abstract when the property is required
        public virtual UsbHidReport report
            {
                get{
                    //do whetever you want or return your default value
                    return MyDefaultReposrt;
                    }
            }
        public virtual UsbHidReportStream  stream
            {
                get{
                    //do whetever you want or return your default value
                    return MyDefaultReportStream;
                    }
            }
    ...
    }
