    public class Item
    {
        [JsonProperty("IdUva")]
        public int GrapeID { get; set; }
        
        [JsonProperty("Uva")]
        public string Grape { get; set; }
        
        [JsonProperty("IdPais")]
        public int ParentID { get; set; }
        
        [JsonProperty("Pais")]
        public string Parent { get; set; }
        
        [JsonProperty("IdProduto")]
        public int ProductID { get; set; }
        
        [JsonProperty("Descricao")]
        public string Description { get; set; }
        
        [JsonProperty("Estoque")]
        public double Stock { get; set; }
        
        [JsonProperty("idVinhoDetalhes")]
        public int WineDetailID { get; set; }
        
        [JsonProperty("Produtor")]
        public string Producer { get; set; }
        
        [JsonProperty("Regiao")]
        public string Region { get; set; }
        
        [JsonProperty("Tipo")]
        public string Type { get; set; }
        
        [JsonProperty("Safra")]
        public string Harvest { get; set; }
        
        /* etc */
    }
