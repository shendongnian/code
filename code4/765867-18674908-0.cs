    public void print (object obje) {
       obje = (Client) obje;
       // OR
       obje = obje as Client;
       Console.WriteLine (obje.Voornaam + " " + obje.Achternaam + " " + obje.Adres + " " + obje.Salaris);
    }
