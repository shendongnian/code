    class Giocatori
    {
        public string Name;
        public string CantantePreferito;
        public int Voto;
        public void NomeECantante()
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            Nome =Console.ReadLine();
            Console.WriteLine(Giocatore + " inserisci il tuo cantante preferito: ");
            CantantePreferito = Console.ReadLine();
            // not
            //string CantantePreferito = Console.ReadLine();
            // otherwise you create a local variable with same name instead of set field Cantante
            Console.WriteLine("Dai un voto da 1 a 10 a " + CantantePreferito + ": ");
            Voto = int.Parse(Console.ReadLine());
        }
    }
