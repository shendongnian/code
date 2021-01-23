    public class Giocatori
    {
        public string Giocatore { get; set; }
        public string Cognome { get; set; }
        public string Ruolo { get; set; }
        public string Squadra { get; set; }
    }
    public class RootObject
    {
        public List<Giocatori> giocatori { get; set; }
        public int success { get; set; }
    }
