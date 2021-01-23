    public class Project{
        public string id{get;set;} 
        public string wetterdatei{get;set;}
        public string fruchtfolge {get;set;} 
        public string bodenprofil {get;set;} 
    }
    public static <class> leseProjektDatei(){
    Project projekt = new Project();
    while ((zeile = datei.ReadLine()) != null)
           {
               Debug.WriteLine(zeile);
               string id, wetterdatei, fruchtfolge, bodenprofil, grundwasser;
               id = zeile.Substring(0, 5);
               wetterdatei = zeile.Substring(7, 14);
               fruchtfolge = zeile.Substring(22, 14);
               bodenprofil = zeile.Substring(37, 14);
           projekt.id = zeile.Substring(0, 5);
           projekt.wetterdatei = zeile.Substring(7, 14);
           projekt.fruchtfolge = zeile.Substring(22, 14);
           projekt.bodenprofil = zeile.Substring(37, 14);
                 } 
    return projekt;
    }
