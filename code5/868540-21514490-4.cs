    using System;
    namespace DUALBIND
    {
    interface IGeneralInfo
    {
        string Info1 {get; }
        string Info2 { get; }
    }
    class OBJA : IGeneralInfo
    {
        public string Info1
        {
            get { return "Info1 is used"; }
        }
        public string Info2
        {
            get { return "Info2 is used"; }
        }
    }
    class OBJB : IGeneralInfo 
    {
        int x;
        public OBJB(int X)
        {
            x = X;
        }
        public string Info1
        {
            get { return "" + x; }
        }
        public string Info2
        {
            get { return ""; /*handle this how you want*/}
        }
    }
    }
