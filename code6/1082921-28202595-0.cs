    If you want to specify that `Results2Detail` et. al. do not belong in a specific (i.e. inherit their namespace from their parent) you can do:
        [DataContract(Namespace="")]
        public class Results2Detail
        {
            [DataMember]
            public RowDetail[] Rows;
        }
        [DataContract(Namespace = "")]
        public class RowDetail
        {
            [DataMember]
            public FieldDetail[] Fields;
        }
        [DataContract(Namespace = "")]
        public class FieldDetail
        {
            [DataMember]
            public String name;
            [DataMember]
            public String value;
        }
    If you want a specific namespace, you can do `[DataContract(Namespace = Namespaces.CompanyNameSpace)]` where `Namespaces` is some static class like:
        public static class Namespaces
        {
            const string CompanyNameSpace = "http://company.namespace.org"; // or whatever.
        }
        
