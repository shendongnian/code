    public class OfflineVerkaufsprei
    {
        public bool Allow_Line_Discount { get; set; }
        public string Date { get; set; }
        public string Item_No { get; set; }
        public string Location_Code { get; set; }
        public double Unit_Price { get; set; }
    }
    public class SetNavRecord
    {
        public string Artikelbeschreibung { get; set; }
        public string Artikelbeschreibung2 { get; set; }
        public string Artikelnummer { get; set; }
        public string Artikelrabattgruppe { get; set; }
        public bool Gutschein { get; set; }
        public string MwStProduktgruppe { get; set; }
        public List<OfflineVerkaufsprei> OfflineVerkaufspreis { get; set; }
    }
    public class RootObject
    {
        public List<SetNavRecord> SetNavRecords { get; set; }
    }
