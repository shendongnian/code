    public interface IRateLimiter
    {
        bool ShouldLimit(string key);
        HttpStatusCode LimitStatusCode { get; }
    }
    public interface IRateLimiterConfiguration
    {
        int Treshhold { get; set; }
        TimeSpan TimePeriod { get; set; }
        HttpStatusCode LimitStatusCode { get; set; }
    }
    public class RateLimiterConfiguration : System.Configuration.ConfigurationSection, IRateLimiterConfiguration
    {
        private const string TimePeriodConst = "timePeriod";
        private const string LimitStatusCodeConst = "limitStatusCode";
        private const string TreshholdConst = "treshhold";
        private const string RateLimiterTypeConst = "rateLimiterType";
        [ConfigurationProperty(TreshholdConst, IsRequired = true, DefaultValue = 10)]
        public int Treshhold
        {
            get { return (int)this[TreshholdConst]; }
            set { this[TreshholdConst] = value; }
        }
        [ConfigurationProperty(TimePeriodConst, IsRequired = true)]
        [TypeConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimePeriod
        {
            get { return (TimeSpan)this[TimePeriodConst]; }
            set { this[TimePeriodConst] = value; }
        }
        [ConfigurationProperty(LimitStatusCodeConst, IsRequired = false, DefaultValue = HttpStatusCode.Forbidden)]
        public HttpStatusCode LimitStatusCode
        {
            get { return (HttpStatusCode)this[LimitStatusCodeConst]; }
            set { this[LimitStatusCodeConst] = value; }
        }
        [ConfigurationProperty(RateLimiterTypeConst, IsRequired = true)]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type RateLimiterType
        {
            get { return (Type)this[RateLimiterTypeConst]; }
            set { this[RateLimiterTypeConst] = value; }
        }
    }
    public class RateLimiter : IRateLimiter
    {
        private readonly IRateLimiterConfiguration _configuration;        
        private static readonly MemoryCache MemoryCache = MemoryCache.Default;
        public RateLimiter(IRateLimiterConfiguration configuration)
        {
            _configuration = configuration;
        }
        public virtual bool ShouldLimit(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                Counter counter = MemoryCache[key] as Counter;
                if (counter == null)
                {
                    MemoryCache.Add(key, new Counter { Count = 1 }, DateTimeOffset.Now.Add(_configuration.TimePeriod));
                }
                else if (counter.Count < _configuration.Treshhold)
                {
                    counter.Count++;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public HttpStatusCode LimitStatusCode
        {
            get { return _configuration.LimitStatusCode; }
        }
        private class Counter
        {
            private volatile int _count;
            public int Count
            {
                get { return _count; }
                set { _count = value; }
            }
        }
    }
    public class RateLimiterFactory
    {
        public IRateLimiter CreateRateLimiter()
        {
            var configuration = GetConfiguration();
            return (IRateLimiter)Activator.CreateInstance(configuration.RateLimiterType, configuration);
        }
    
        public static RateLimiterConfiguration GetConfiguration()
        {
            return ConfigurationManager.GetSection("rateLimiter") as RateLimiterConfiguration ?? new RateLimiterConfiguration();
        }
    }
    static class GetClientIpExtensions
    {
        private const string XForwardedForHeaderName = "X-Forwarded-For";
        private const string HttpXForwardedForServerVariableName = "HTTP_X_FORWARDED_FOR";
        private const string HttpRemoteAddressServerVariableName = "REMOTE_ADDR";
        public static string GetClientIp(this Message message)
        {
            return GetClientIp(message.Properties);
        }
        public static string GetClientIp(this OperationContext context)
        {
            return GetClientIp(context.IncomingMessageProperties);
        }
        public static string GetClientIp(this MessageProperties messageProperties)
        {
            var endpointLoadBalancer = messageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            if (endpointLoadBalancer != null && endpointLoadBalancer.Headers[XForwardedForHeaderName] != null)
            {
                return endpointLoadBalancer.Headers[XForwardedForHeaderName];
            }
            else
            {
                var endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                return (endpointProperty == null) ? string.Empty : endpointProperty.Address;
            }
        }
        public static string GetClientIp(this HttpRequest request)
        {
            string ipList = request.ServerVariables[HttpXForwardedForServerVariableName];
            return !string.IsNullOrEmpty(ipList) ? ipList.Split(',')[0] : request.ServerVariables[HttpRemoteAddressServerVariableName];
        }
    }
