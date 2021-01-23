     public Giocatore LoadGiocatoreData()
     {
         string nome;
         string cantante;
         int voto;
         Console.WriteLine("Inserisci il tuo nome: ");
         nome = Console.ReadLine();
         Console.WriteLine(nome + " inserisci il tuo cantante preferito: ");
         string cantante = Console.ReadLine();
         Console.WriteLine("Dai un voto da 1 a 10 a " + cantante + ": ");
         if(!Int32.TryParse(Console.ReadLine(), out voto))
         {
             Console.WriteLine("Please insert a number");
             return null;
         }
         Giocatore g = new Giocatore(nome, cantante, voto);
         return g;
     }
