    [ToolboxItemAttribute(false)]
    public partial class ChargeWebPart: WebPart
    {
        private double _investorPct;// = 0.0;
        private double _founderPct;// = 0.0;
        [WebBrowsable(true), Personalizable(PersonalizationScope.Shared)]
        public double FounderPct
        {
            get
            {
                return _founderPct;
            }
            set
            {
                _founderPct = value;
            }
        }
        [WebBrowsable(true), Personalizable(PersonalizationScope.Shared)]
        public double InvestorPct
        {
            get
            {
                return _investorPct;
            }
            set
            {
                _investorPct = value;
            }
        }
        public ChargeWebPart()
        {
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
