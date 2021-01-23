        public class PageHit
        {
            public DateTime RequestTime { get; set; }
            public int PageResponseTime { get; set; }
            public DateTime GetRequestTimeToNearest30Mins()
            {
                return RoundUp(RequestTime, TimeSpan.FromMinutes(30));
            }
        }
