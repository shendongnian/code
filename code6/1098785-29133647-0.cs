    internal sealed class ResultData
    {
        private readonly string piWebReport;
        public ResultData(string piWebReport)
        {
            this.piWebReport = piWebReport;
        }
        public string PiWebReport
        {
            get { return this.piWebReport; }
        }
    }
