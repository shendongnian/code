    public class Item
    {
        public int IdUva { get; set; }
        public string Uva { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public double Estoque { get; set; }
        public int idVinhoDetalhes { get; set; }
        public string Produtor { get; set; }
        public string Regiao { get; set; }
        public string Tipo { get; set; }
        public string Safra { get; set; }
        public double Teor { get; set; }
        public string FichaTecnica { get; set; }
        public string Servico { get; set; }
        public string Mapa { get; set; }
        public string Foto { get; set; }
        public double Preco { get; set; }
        public int CodigoPais { get; set; }
        public string Bandeira { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> items { get; set; }
    }
