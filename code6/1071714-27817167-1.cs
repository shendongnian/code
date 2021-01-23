    public class Subcategories
    {
        public int __invalid_name__6 { get; set; }
    }
    
    public class ClientData
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string ulica { get; set; }
        public string nr_budynku { get; set; }
        public string nr_lokalu { get; set; }
        public string kod_pocztowy { get; set; }
        public string miejscowosc { get; set; }
        public string samochod_marka { get; set; }
        public string samochod_model { get; set; }
        public Subcategories subcategories { get; set; }
    }
    
    public class RootObject
    {
        public string status { get; set; }
        public string message { get; set; }
        public ClientData clientData { get; set; }
    }
