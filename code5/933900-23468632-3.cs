       public class Address
        {
            public string Street1 { get; set; }
            public string Street2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostCode { get; set; }
        }
        [System.Web.Services.WebMethod]
        public static string GetPostData(List<Address> addresses)
        {
            // addresses[0].Street1;
            // addresses[0].City;
            return null;
        }
