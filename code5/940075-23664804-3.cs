    [WebMethod]
    public static void CreareCont(Inregistrare user)
    {
        string hash = helper.GetSHA1HashData("123");
    
    }
    public class Inregistrare
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNPsauCUI { get; set; }
        public string Strada { get; set; }
        public string Numar { get; set; }
        public string Etaj { get; set; }
        public string Apartament { get; set; }
        public string Oras { get; set; }
        public string SectorSauJudet { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
    }
