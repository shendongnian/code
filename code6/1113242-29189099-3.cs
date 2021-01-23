    public class AcademiaViewModel
    {
        public List<CwcConteudos> CwcConteudos {get; set;}
        public List<Ficheiroconteudos> FicheiroconteudosList {get; set;}
    }
    public class Ficheiroconteudos 
    {
        public string IdFilic {get; set;}
        ...add the rest of the properties of the anonymous type
    }
