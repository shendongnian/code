    [XmlRoot("return")]
    class ResultWrapper
    {
        [XmlElement("LuckNumber")] 
        public List<GenerateNumberResult> numberList;
    }
