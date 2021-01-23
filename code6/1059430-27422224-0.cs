    public class Usuario
    {
        public string Nome { get; set; }
        public string Token { get; set; }
        public string Unidade { get; set; }
        public IEnumerable<SelectListItem> Unidades { get; set; }
    }
