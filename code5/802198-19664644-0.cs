    public class VecozoURLBuilder
    {
        private string _dobFormatted;
        private string _infodateFormatted;
        private string _bsn;
        private string _insuranceID;
        ...
        public VecozoURLBuilder DobFormatted(string dobFormatted)
        {
            _dobFormatted = dobFormatted;
            return this;
        }
        public VecozoURLBuilder InfodateFormatted(string infodateFormatted)
        {
            _infodateFormatted= nfodateFormatted;
            return this;
        }
        ...
        public string VecozoURL()
        {
            // create string from dobFormatted  etc.
        }
    }
