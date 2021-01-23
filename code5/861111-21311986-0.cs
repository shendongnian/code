    public static void generateCTAF(string pathXml, string outputPDF)
    {
        // do not initialize fc variable with empty list
        List<FichierCTAF> fc = getXmlFCtaf(pathXml); 
        foreach (FichierCTAF f in fc)
        {
            Console.WriteLine("ID CTAF : {0}", f.IdFichierCtaf);
            foreach(var client in f.Clients) // select client here
            {
                 // display Nom of current client
                 Console.WriteLine(" Nom Client : {0}", client.NomClient);
                 // enumerate comptes clients of current client
                 foreach (var comptesClient in client.ComptesClient))
                   Console.WriteLine(" Num Compte : {0}\n", comptesClient.NumCompte);
            }
        }
    }
