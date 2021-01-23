    public class PostalCodeAttribute : Attribute { }
    public class USPostalCodeAttribute: PostalCodeAttribute { }
    public class GBPostalCodeAttribute: PostalCodeAttribute{ }
    public interface IPostalCodeModel
    {
        string PostalCode { get; }
    }
    public class UsModel : IPostalCodeModel
    {
        [UsPostalCode]
        public string PostalCode { get; set; }
    }
    
    public class GbModel : IPostalCodeModel
    {
        [GbPostalCode]
        public string PostalCode { get; set; }
    }
