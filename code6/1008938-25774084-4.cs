    static void Main(string[] args)
    {
        ....
        int GiocatoriN;
        if(!Int32.TryParse(Console.ReadLine(), out GiocatoriN))
        {
            Console.WriteLine("Write a number please");
            return;
        }
        List<Giocatore> giocatori = new List<Giocatore>();
        for (int i = 0; i < GiocatoriN; i++)
        {
            Giocatore g = LoadGiocatoreData();
            if(g == null)
              return;
            giocatori.Add(g);
        } 
    }
