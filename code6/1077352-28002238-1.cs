    public class InvestigationBox : IInvestigationBox
    {
        private long BoxId { get; set; }
        private string BoxIP { get; set; }
        public InvestigationBox(string boxip, int port)
        {
            this.BoxIP = boxip;
            this.BoxPort = port;
        }
    } public interface IInvestigationBox
    {}
