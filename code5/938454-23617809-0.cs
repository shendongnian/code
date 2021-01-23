    [Serializable]
    [XmlRoot("Sklep")]
    public class Sklep : IKlient, IProdukt, IRachunek, IWKlient, IWProdukt, IWRachunek
    {
        [XmlArray,XmlArrayItem]
        public List<Klient> listKlienci = new List<Klient>();
        [XmlArray,XmlArrayItem]
        public List<Produkt> listProdukty = new List<Produkt>();
        [XmlArray,XmlArrayItem]
        public ObservableCollection<Rachunek> ocRachunki
