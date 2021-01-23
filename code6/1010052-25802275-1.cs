    public class Project{
        public string id{get;set;} 
        public string wetterdatei{get;set;}
        public string fruchtfolge {get;set;} 
        public string bodenprofil {get;set;} 
    }
    public static Project leseProjektDatei(){
    Project projekt = new Project();
    while ((zeile = datei.ReadLine()) != null)
           {
               projekt.id = zeile.Substring(0, 5);
               projekt.wetterdatei = zeile.Substring(7, 14);
               projekt.fruchtfolge = zeile.Substring(22, 14);
               projekt.bodenprofil = zeile.Substring(37, 14);
                 } 
    return projekt;
    }
