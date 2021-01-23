    public class MyData
    {
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
 
    string fragment = @"<Addr1>2</Addr1>
                        <Addr2>2</Addr2>
                        <Addr3>2</Addr3>
                        <Addr4>2</Addr4>
                        <City>2</City>
                        <State>2</State>
                        <PostalCode>2</PostalCode>
                        <Country>2</Country>"; 
    var result = DeserializeFragment<MyData>(fragment);
