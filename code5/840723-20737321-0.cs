    public class HistoryResponseContainer
    {
        public ResponseInfo response { get; set; }
        public HistoryInfo history { get; set; }
    }
    public class ResponseInfo
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public Dictionary<string, int> features { get; set; }
    }
    public class HistoryInfo
    {
        public WUDate date { get; set; }
        public WUDate utcdate { get; set; }
        public Observation[] observations { get; set; }
        public Dailysummary[] dailysummary { get; set; }
    }
    public class WUDate
    {
        public string pretty { get; set; }
        public string year { get; set; }
        public string mon { get; set; }
        public string mday { get; set; }
        public string hour { get; set; }
        public string min { get; set; }
        public string tzname { get; set; }
        public DateTime Value
        {
            get
            {
                int year = int.Parse(this.year);
                int month = int.Parse(this.mon);
                int day = int.Parse(this.mday);
                int hour = int.Parse(this.hour);
                int minute = int.Parse(this.min);
                var kind = this.tzname == "UTC"
                    ? DateTimeKind.Utc
                    : DateTimeKind.Unspecified;
                return new DateTime(year, month, day, hour, minute, 0, kind);
            }
        }
    }
    public class Observation
    {
        public WUDate date { get; set; }
        public WUDate utcdate { get; set; }
        public string tempm { get; set; }
        public string tempi { get; set; }
        public string dewptm { get; set; }
        public string dewpti { get; set; }
        public string hum { get; set; }
        public string wspdm { get; set; }
        public string wspdi { get; set; }
        public string wgustm { get; set; }
        public string wgusti { get; set; }
        public string wdird { get; set; }
        public string wdire { get; set; }
        public string vism { get; set; }
        public string visi { get; set; }
        public string pressurem { get; set; }
        public string pressurei { get; set; }
        public string windchillm { get; set; }
        public string windchilli { get; set; }
        public string heatindexm { get; set; }
        public string heatindexi { get; set; }
        public string precipm { get; set; }
        public string precipi { get; set; }
        public string conds { get; set; }
        public string icon { get; set; }
        public string fog { get; set; }
        public string rain { get; set; }
        public string snow { get; set; }
        public string hail { get; set; }
        public string thunder { get; set; }
        public string tornado { get; set; }
        public string metar { get; set; }
    }
    
    public class Dailysummary
    {
        public WUDate date { get; set; }
        public string fog { get; set; }
        public string rain { get; set; }
        public string snow { get; set; }
        public string snowfallm { get; set; }
        public string snowfalli { get; set; }
        public string monthtodatesnowfallm { get; set; }
        public string monthtodatesnowfalli { get; set; }
        public string since1julsnowfallm { get; set; }
        public string since1julsnowfalli { get; set; }
        public string snowdepthm { get; set; }
        public string snowdepthi { get; set; }
        public string hail { get; set; }
        public string thunder { get; set; }
        public string tornado { get; set; }
        public string meantempm { get; set; }
        public string meantempi { get; set; }
        public string meandewptm { get; set; }
        public string meandewpti { get; set; }
        public string meanpressurem { get; set; }
        public string meanpressurei { get; set; }
        public string meanwindspdm { get; set; }
        public string meanwindspdi { get; set; }
        public string meanwdire { get; set; }
        public string meanwdird { get; set; }
        public string meanvism { get; set; }
        public string meanvisi { get; set; }
        public string humidity { get; set; }
        public string maxtempm { get; set; }
        public string maxtempi { get; set; }
        public string mintempm { get; set; }
        public string mintempi { get; set; }
        public string maxhumidity { get; set; }
        public string minhumidity { get; set; }
        public string maxdewptm { get; set; }
        public string maxdewpti { get; set; }
        public string mindewptm { get; set; }
        public string mindewpti { get; set; }
        public string maxpressurem { get; set; }
        public string maxpressurei { get; set; }
        public string minpressurem { get; set; }
        public string minpressurei { get; set; }
        public string maxwspdm { get; set; }
        public string maxwspdi { get; set; }
        public string minwspdm { get; set; }
        public string minwspdi { get; set; }
        public string maxvism { get; set; }
        public string maxvisi { get; set; }
        public string minvism { get; set; }
        public string minvisi { get; set; }
        public string gdegreedays { get; set; }
        public string heatingdegreedays { get; set; }
        public string coolingdegreedays { get; set; }
        public string precipm { get; set; }
        public string precipi { get; set; }
        public string precipsource { get; set; }
        public string heatingdegreedaysnormal { get; set; }
        public string monthtodateheatingdegreedays { get; set; }
        public string monthtodateheatingdegreedaysnormal { get; set; }
        public string since1sepheatingdegreedays { get; set; }
        public string since1sepheatingdegreedaysnormal { get; set; }
        public string since1julheatingdegreedays { get; set; }
        public string since1julheatingdegreedaysnormal { get; set; }
        public string coolingdegreedaysnormal { get; set; }
        public string monthtodatecoolingdegreedays { get; set; }
        public string monthtodatecoolingdegreedaysnormal { get; set; }
        public string since1sepcoolingdegreedays { get; set; }
        public string since1sepcoolingdegreedaysnormal { get; set; }
        public string since1jancoolingdegreedays { get; set; }
        public string since1jancoolingdegreedaysnormal { get; set; }
    }
