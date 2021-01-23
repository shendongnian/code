    class ReturnClass
    {
        public string QRCode { get; set; }
        public bool IsOK { get; set; }
    }
    public ReturnClass MainMethod()
    {
        ReturnClass mrc = new ReturnClass();
        // Do checks and populate value of ReturnClass
        return mrc;
    }
