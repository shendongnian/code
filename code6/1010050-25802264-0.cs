    public static IEnumerable<YourClass> leseProjektDatei()
    {
    var list = new List<YourClass>();
    while ((zeile = datei.ReadLine()) != null)
           {
               Debug.WriteLine(zeile);
               string id, wetterdatei, fruchtfolge, bodenprofil, grundwasser;
               id = zeile.Substring(0, 5);
               wetterdatei = zeile.Substring(7, 14);
               fruchtfolge = zeile.Substring(22, 14);
               bodenprofil = zeile.Substring(37, 14);
    
    
               list.Add(new YourClass(id, wetterdatei, fruchtfolge, bodenprofil));
    
           } 
    return list;
    }
