    public abstract class TrustablePerson : Person
    {
        public NHSTrust NHSTrust { get; set; }
    }
    public class Contact : TrustablePerson
    {
        public Nullable<int> NHSTrustID { get; set; }
    }
    public class User : TrustablePerson
    {
        public int NHSTrustID { get; set; }
    }
