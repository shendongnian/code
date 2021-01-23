    public class ClientDetailModel
        {
            public ClientDetailModel()
            {
                Prev_Doc_List = new List<PreviousDocuments>();
            }
            public string Name { get; set; }
            public string Id { get; set; }
            public string DOB { get; set; }
            public string Address { get; set; }
            public string OtherAddressDetails { get; set; }
            public string Phone { get; set; }
            public string Mobile_Phone { get; set; }
            public DateTime Client_DOB { get; set; }
            public List<PreviousDocuments> Prev_Doc_List { get; set; }
    
        }
        public class PreviousDocuments
        {
            public string Created_Date { get; set; }
            public string Doc_type { get; set; }
            public string Provider { get; set; }
            public string Page_ID { get; set; }
            public string RedirectAddress { get; set; }
        }
