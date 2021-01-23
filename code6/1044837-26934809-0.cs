    public class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(CheckStatus(Status.ReadableNameOne));
            Debug.WriteLine(CheckStatus(Status.ReadableNameFourtyNine));
        }
        public static VocabularyEnum CheckStatus(Status currentStatus)
        {
            var result = Enum.GetValues(typeof(VocabularyEnum)).Cast<object>().Where(e =>
                ((XmlEnumAttribute)typeof(VocabularyEnum)
                        .GetMember(e.ToString())[0]
                        .GetCustomAttributes(typeof(XmlEnumAttribute), false)[0])
                        .Name == ((int)currentStatus).ToString()).FirstOrDefault();
            if (result != null)
                return (VocabularyEnum)result;
            else
                throw new ArgumentOutOfRangeException("currentStatus");
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("cxsc", "0.57.0.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(TypeName = "voc.Status",
                                                   Namespace = "http://somenamespace/opennamespace")]
        public enum VocabularyEnum
        {
            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("1")]
            Item1,
            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("2")]
            Item2,
            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("3")]
            Item3,
            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("49")]
            Item49,
        }
        public enum Status : byte
        {
            ReadableNameOne = 1,
            ReadableNameTwo = 2,
            ReadableNameThree = 3,
            ReadableNameFourtyNine = 49
        }
    }
