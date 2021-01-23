    //Request DTO
    [Route("/products/{ProductId}/updates/{ProductVersion}")]
    [Route("/products/{ProductId}/updates")]
    [Route("/json/syncreply/productupdate", Verbs="POST")]
    public class ProductUpdate
    {
        public string ProductId { get; set; }
        public string ProductVersion { get; set; }
        public string MachineCode { get; set; }
        public string LicenseId { get; set; }
    }
