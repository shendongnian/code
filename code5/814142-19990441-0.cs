        [DataContract(Name = "GetTestURL", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public class TestInfo
        {
            public TestInfo() { }
            public TestInfo(Uri uri, int userCount, int initialCount, int averageExecutionTime)
            {
                TestUri = uri;
                UserCount = userCount;
                InitialCount = initialCount;
                AverageExecutionTime = averageExecutionTime;
            }
            [DataMember(Name = "TestURL", IsRequired=true, Order=1)]
            public Uri TestUri { get; private set; }
            [DataMember(Name = "UserCount", IsRequired=true, Order=2)]
            public int UserCount { get; private set; }
            [DataMember(Name = "InitialCount", IsRequired=true, Order=3)]
            public int InitialCount { get; private set; }
            [DataMember(Name = "AverageExecutionTime", IsRequired=true, Order=4)]
            public int AverageExecutionTime { get; private set; }
        }
