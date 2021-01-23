    using System;
    namespace les2
    {
      public class client
      {
        public string Voornaam;
        public string Achternaam;
        public string Adres;
        public int Salaris;
        public client (string voornaam, string achternaam, string adres, int salaris)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Adres = adres;
            Salaris = salaris;
        }
        public void print()
        {
            Console.WriteLine (Voornaam + " " + Achternaam + " " + Adres + " " + Salaris);
        }
      }
      class MainClass
      {
        public static void Main (string[] args)
        {
            client gegevens1 = new client("Dylan", "Westra", "Rozengracht 34", 1200);
            gegevens1.print();
        }
      }
    }
