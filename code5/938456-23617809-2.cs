    [XmlRoot]
    public class Sklep
    {
        [XmlArray, XmlArrayItem]
        public List<Klient> listKlienci = new List<Klient>();
    }
    [XmlType]
    public class Klienci
    {
        [XmlElement]
        public string Imie;
    }
