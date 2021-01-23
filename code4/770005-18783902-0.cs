    public class NameWithEmail : Name {
        public string EMail {get;set;}
    }
    ...
    public Name LoadName() {
        ...
        return new NameWithEmail(); // OK because NameWithEmail extends Name
    }
