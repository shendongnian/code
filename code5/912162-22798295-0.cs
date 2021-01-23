    public class OuterRootObject
    {
        public string d { get; set; }
    }
    public class Globals
    {
        public bool MultiSessionsAllowed { get; set; }
        public int CommCalcType { get; set; }
        public int PriceChangedTimer { get; set; }
        public int ValidLotsLocation { get; set; }
        public bool CustumizeTradeMsg { get; set; }
        public object FirstWhiteLabeledOffice { get; set; }
        public int DealerTreePriv { get; set; }
        public int ClientConnectTimer { get; set; }
        public int ClientTimeoutTimer { get; set; }
        public double DefaultLots { get; set; }
        public string WebSecurityID { get; set; }
        public int ServerGMT { get; set; }
    }
    public class VersionInfo
    {
        public int Rel { get; set; }
        public int Ver { get; set; }
        public int Patch { get; set; }
        public int ForceUpdate { get; set; }
        public int UpdateType { get; set; }
        public Globals Globals { get; set; }
    }
    public class SystemLockInfo
    {
        public int MinutesRemaining { get; set; }
        public int HoursRemaining { get; set; }
        public int DaysRemaining { get; set; }
        public int Maintanance { get; set; }
        public int WillBeLocked { get; set; }
    }
    public class RootObject
    {
        public string sessionid { get; set; }
        public VersionInfo VersionInfo { get; set; }
        public SystemLockInfo SystemLockInfo { get; set; }
        public string FirstWhiteLabel { get; set; }
        public string WLID { get; set; }
        public bool CheckWhiteLabel { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime LastTickTime { get; set; }
        public int SelectedAccount { get; set; }
        public int Name { get; set; }
        public object ServicePath { get; set; }
        public string GWSessionID { get; set; }
        public string IP { get; set; }
        public string SessionDateStart { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public string DemoClient { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string TName { get; set; }
        public string LName { get; set; }
        public object Sms { get; set; }
        public string isReadOnly { get; set; }
        public string SchSms { get; set; }
        public string AlertSms { get; set; }
        public object Temp { get; set; }
        public string GMTOffset { get; set; }
        public string SvrGMT { get; set; }
        public object ClientType { get; set; }
        public string EnableNews { get; set; }
        public string PublicSlideNews { get; set; }
        public string PrivateSlideNews { get; set; }
        public int DealerTreePriv { get; set; }
    }
    var outerRoot = JsonConvert.DeserializeObject<OuterRootObject>( json );
    var root = JsonConvert.DeserializeObject<RootObject>( outerRoot.d );
