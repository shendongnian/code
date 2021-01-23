    static void Main(string[] args)
    {
        var doc = XDocument.Parse(
                @"<Anzeige>
                    <Kunde>
                        <KundNr>111</KundNr>
                        <Nachname>111</Nachname>
                        <Vorname>111</Vorname> 
                    </Kunde>
                    <Kunde>
                        <KundNr>222</KundNr>                            
                        <Nachname>222</Nachname>
                        <Vorname>222</Vorname> 
                    </Kunde>
                </Anzeige>");
        ExtractClients(doc);
        var docWithMissingValues = XDocument.Parse(
                @"<Anzeige>
                    <Kunde>
                        <KundNr>111</KundNr>
                        <Vorname>111</Vorname> 
                    </Kunde>
                    <Kunde>
                        <KundNr>222</KundNr>                            
                        <Nachname>222</Nachname>
                    </Kunde>
                    <Kunde>
                    </Kunde>
                </Anzeige>");
        ExtractClients(docWithMissingValues);
        var docWithoutAnzeigeNode = XDocument.Parse(
                @"<AnotherNode>
                    <Kunde>
                        <KundNr>111</KundNr>
                        <Vorname>111</Vorname> 
                    </Kunde>
                </AnotherNode>");
        ExtractClients(docWithoutAnzeigeNode);
        var docWithoutKundeNodes = XDocument.Parse(
                @"<Anzeige>
                    <OtherNode></OtherNode>
                </Anzeige>");
        ExtractClients(docWithoutKundeNodes);
        var emptyDoc = new XDocument();
        ExtractClients(emptyDoc);
        Console.ReadLine();
    }
    private static void ExtractClients(XDocument doc)
    {
        var clients = doc.Descendants("Anzeige").Descendants("Kunde").Select(p => new Client()
        {
            //You can manually get the value like this:
            //IdClient = p.Element("KundNr") != null ? p.Element("KundNr").Value : String.Empty,
            //NomClient = p.Element("Nachname") != null ? p.Element("Nachname").Value : String.Empty,
            //PrenomClient = p.Element("Vorname") != null ? p.Element("Vorname").Value : String.Empty
            //Or directly cast the node value to the type (value types or strings) required like:
            IdClient = (int?) p.Element("KundNr") ?? -1,
            NomClient = (string) p.Element("Nachname") ?? String.Empty,
            PrenomClient = (string) p.Element("Vorname") ?? String.Empty
        }).ToList();
        Console.WriteLine();
        foreach (var client in clients)
        {
            Console.WriteLine("{0},{1},{2}", client.IdClient, client.NomClient, client.PrenomClient);
        }
        Console.WriteLine(new string('-',30));
    }
    public class Client
    {
        // Personne Physique
        public int IdClient { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public Client() { }
    }
