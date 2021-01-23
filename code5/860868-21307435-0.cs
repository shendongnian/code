    public static void generateCTAF(string pathXml, string outputPDF)
    {
        List<FichierCTAF> fc = getXmlFCtaf(pathXml);
        foreach (FichierCTAF f in fc)
        {
            Console.WriteLine("ID CTAF : {0}\n Nom Client : {1}\n\n", 
               f.IdFichierCtaf, 
               String.Join(", ", f.Clients.Select(y => y.NomClient)));
        }
    }
