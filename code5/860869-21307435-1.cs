    public static void generateCTAF(string pathXml, string outputPDF)
    {
        List<FichierCTAF> fc = getXmlFCtaf(pathXml);
        foreach (FichierCTAF f in fc)
        {
            Console.WriteLine("ID CTAF : {0}", f.IdFichierCtaf);
            foreach(string nomClient in f.Clients.Select(y => y.NomClient))
                Console.WriteLine(" Nom Client : {0}", nomClient);
        }
    } 
