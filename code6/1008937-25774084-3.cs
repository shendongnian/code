    class Giocatore
    {
        public string Nome {get;set;}
        public string CantantePreferito {get;set;}
        public int Voto {get;set;}
        public Giocatore(string nome, string cantante, int voto)
        {
           this.Nome = nome;
           this.CantantePreferito = cantante;
           this.Voto = voto;
        }
    }
