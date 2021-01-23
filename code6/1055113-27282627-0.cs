    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentificationNumber { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public bool DeadHead { get; set; }
        public virtual PassportInfo Passport { get; set; }
        public virtual PassportInfo DriverLicense { get; set; }
        public virtual PassportInfo PensionCertificate { get; set; }
        public virtual AddressInfo ResidenseAddress { get; set; }
        public virtual AddressInfo RegistrationAddress { get; set; }
    }
    public class PassportInfo
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public int Number { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssueDate { get; set; }
        
        public virtual Person Person { get; set; }
    }
    public class AddressInfo
    {
        public int Id { get; set; }
        public string Index { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public int House { get; set; }
        public int Apartment { get; set; }
        public int? StreetTypeId { get; set; }
        public StreetType StreetType { get; set; }
        public int? LocalityTypeId { get; set; }
        public LocalityType LocalityType { get; set; }
        
        public virtual Person Person { get; set; }
    }
