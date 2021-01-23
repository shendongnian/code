    public class SearchParameters
    {
        public string key { get; set; }
        public string system { get; set; }
    }
    
        public class Self
    {
        public string href { get; set; }
    }
    
    public class LinKs
    {
        public Self self { get; set; }
    }
    
    public class Period
    {
        public string start { get; set; }
        public string end { get; set; }
    }
    
    public class Address
    {
        public List<string> line { get; set; }
        public string city { get; set; }
        public string __invalid_name__state { get; set; }
        public string zip { get; set; }
        public Period period { get; set; }
    }
    
    public class PerioD2
    {
        public string start { get; set; }
        public string end { get; set; }
    }
    
    public class Name
    {
        public string use { get; set; }
        public List<string> family { get; set; }
        public List<string> given { get; set; }
        public PerioD2 __invalid_name__perio
    d { get; set; }
    }
    
    public class Gender
    {
        public string __invalid_name__co
    de { get; set; }
        public string display { get; set; }
    }
    
    public class Period3
    {
        public string start { get; set; }
        public string __invalid_name__end { get; set; }
    }
    
    public class Identifier
    {
        public string use
     { get; set; }
        public string system { get; set; }
        public string key { get; set; }
        public Period3 period { get; set; }
    }
    
    public class Period4
    {
        public string start { get; set; }
        public string end { get; set; }
    }
    
    public class Telecom
    {
        public string system { get; set; }
        public string value { get; set; }
        public string use { get; set; }
        public Period4 period { get; set; }
    }
    
    public class Content
    {
        public string contentType { get; set; }
        public string language { get; set; }
        public string __invalid_name__dat
    a { get; set; }
        public int size { get; set; }
        public string hash { get; set; }
        public string title { get; set; }
    }
    
    public class Photo
    {
        public Content content { get; set; }
    }
    
    public class Details
    {
        public List<Address> address { get; set; }
        public List<Name> name { get; set; }
        public Gender gender { get; set; }
        public string birthDate { get; set; }
        public List<Identifier> identifier { get; set; }
        public List<Telecom> telecom { get; set; }
        public List<Photo> photo { get; set; }
    }
    
    public class EnrollmentSummary
    {
        public string dateEnrolled { get; set; }
        public string __invalid_name__en
    roller { get; set; }
    }
    
    public class Self2
    {
        public string href { get; set; }
    }
    
    public class UnEnroll
    {
        public string href { get; set; }
    }
    
    public class PersonLink
    {
        public string href { get; set; }
    }
    
    public class PersonMatch
    {
        public string href { get; set; }
    }
    
    public class Links2
    {
        public Self2 self { get; set; }
        public UnEnroll __invalid_name__un
    enroll { get; set; }
        public PersonLink personLink { get; set; }
        public PersonMatch personMatch { get; set; }
    }
    
    public class Person
    {
        public Details details { get; set; }
        public bool __invalid_name__e
    nrolled { get; set; }
        public EnrollmentSummary enrollmentSummary { get; set; }
        public Links2 _links { get; set; }
    }
    
    public class Embedded
    {
        public List<Person> person { get; set; }
    }
    
    public class RootObject
    {
        public SearchParameters searchParameters { get; set; }
        public string message { get; set; }
        public LinKs __invalid_name___lin
    ks { get; set; }
        public Embedded _embedded { get; set; }
    }
