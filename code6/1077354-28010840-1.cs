    public class LoginCheckController : ApiController
    {
        private IInvestigationBoxFactory _iInvestigationBoxFactory { get; set; }
        private IInvestigationBox _iInvestigationBox { get; set; }
        public LoginCheckController(IInvestigationBoxFactory iInvestigationBoxFactory)
        {
            this._iInvestigationBoxFactory = iInvestigationBoxFactory;
            _iInvestigationBox = _iInvestigationBoxFactory.Create("100.200", 1020);
        }
    }
