    public class Headers
        {
            public string Token { get; set; }
            public int UserId { get; set; }
            public int AccountId { get; set; }
            [XmlIgnore]
            public Uri host { get; set; }
            public static string requestMethod = "POST";
        }
	[XmlRoot("request")]
	public class GetActivityDetailsByActivityId : Headers
        {
            public string responseType = "ResponseGetActivityDetailsByActivityId";
            public class MethodDetails
            {
                public string methodName = "GetActivityDetailsByActivityId";
                public int activtyId;
                public DateTime activityDate;
                
            }
            [XmlElement("Method")]
            public MethodDetails Method = new MethodDetails();
            public GetActivityDetailsByActivityId(int activityId, DateTime activityDate,Headers headers)
            {
                this.Method.activityDate = activityDate;
                this.Method.activtyId = activityId;
                
                this.AccountId = headers.AccountId;
                this.Token = headers.Token;
                this.UserId = headers.UserId;
                this.host = headers.host;
            }
            GetActivityDetailsByActivityId()
            {
            }
        }
