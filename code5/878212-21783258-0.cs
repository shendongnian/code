    public class Cartuxa
    {
        public class Home
        {
            public object id { get; set; }
            public string menu { get; set; }
            public string title { get; set; }
            public string image { get; set; }
            public string url { get; set; }
        }
        public class Artigo
        {
            public string menu { get; set; }
            public string submenu { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public string description { get; set; }
            public List<object> media { get; set; }
        }
        public class Year
        {
            public string year { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string file { get; set; }
            public string url { get; set; }
        }
        public class Product
        {
            public string id { get; set; }
            public string image { get; set; }
            public string url { get; set; }
            public List<Year> year { get; set; }
        }
        public class Vinho
        {
            public string id { get; set; }
            public string menu { get; set; }
            public string submenu { get; set; }
            public string title { get; set; }
            public List<Product> product { get; set; }
        }
        public class Year2
        {
            public string year { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string file { get; set; }
            public string url { get; set; }
        }
        public class Product2
        {
            public string id { get; set; }
            public string image { get; set; }
            public string url { get; set; }
            public List<Year2> year { get; set; }
        }
        public class Azeite
        {
            public string id { get; set; }
            public string menu { get; set; }
            public string submenu { get; set; }
            public string title { get; set; }
            public List<Product2> product { get; set; }
        }
        public class Agente
        {
            public string id { get; set; }
            public string continent_id { get; set; }
            public string country_id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
        }
        public class Continente
        {
            public string id { get; set; }
            public string title { get; set; }
        }
        public class Pais
        {
            public string id { get; set; }
            public string continent_id { get; set; }
            public string title { get; set; }
        }
        public class Contacto
        {
            public string id { get; set; }
            public string menu_id { get; set; }
            public string submenu_id { get; set; }
            public string title { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string fax { get; set; }
            public string longitude { get; set; }
            public string latitude { get; set; }
        }
        public class Premio
        {
            public string image { get; set; }
            public string url { get; set; }
        }
        public class Noticia
        {
            public string id { get; set; }
            public string menu { get; set; }
            public string date_created { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public string description { get; set; }
            public List<object> media { get; set; }
        }
        public class RootObject
        {
            public List<Home> home { get; set; }
            public List<Artigo> artigos { get; set; }
            public List<Vinho> vinhos { get; set; }
            public List<Azeite> azeites { get; set; }
            public List<Agente> agentes { get; set; }
            public List<Continente> continentes { get; set; }
            public List<Pais> paises { get; set; }
            public List<Contacto> contactos { get; set; }
            public List<Premio> premios { get; set; }
            public List<Noticia> noticias { get; set; }
        }
    }
