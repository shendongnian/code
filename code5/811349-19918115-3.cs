    [JsonObject(MemberSerialization.OptIn)]
    public class Especie
    {
        private string m_imagePath;
    
        [JsonProperty]
        public Tipo { get; set; }
        
        [JsonProperty]
        public string Nombre { get; set; }
        
        [JsonProperty]
        public int TiempoDeVida { get; set; }
    
        [JsonProperty]
        public int Movilidad { get; set; }
    
        [JsonProperty]
        public int Decaimiento { get; set; }
    
        [JsonProperty]
        public string ColorDeLaGrafica { get; set; }
    
        [JsonProperty]
        public bool Seleccion { get; set; }
    
        // not serialized because mode is opt-in
        public Bitmap Imagen { get; private set; }
    
        [JsonProperty]
        public string ImagePath
        {
            get { return m_imagePath; }
            set
            {
                m_imagePath = value;
                Imagen = Bitmap.FromFile(m_imagePath);
            }
        }
    }
