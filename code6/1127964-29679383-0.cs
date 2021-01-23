    [XmlRoot("ArrayOfBloc")]
    public class BlocContainer
    {
        [XmlElement("Bloc")]
        public List<Bloc> BlocCollection { get; set; }
    }
