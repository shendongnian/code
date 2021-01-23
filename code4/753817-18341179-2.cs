    public class PostalCodeAttribute : Attribute
    {
        public string Country { get; set; }
    }
    public interface IPostalCodeModel
    {
        string PostalCode { get; }
    }
    public class UsModel : IPostalCodeModel
    {
        [PostalCode(Country = "en-US")]
        public string PostalCode { get; set; }
    }
    
    public class GbModel : IPostalCodeModel
    {
        [PostalCode(Country = "en-GB")]
        public string PostalCode { get; set; }
    }
