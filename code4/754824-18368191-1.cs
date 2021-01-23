    [XmlRoot("return")]
    public class ResultWrapper
    {
        [XmlElement("LuckNumber")] 
        public List<GenerateNumberResult> numberList;
    }
