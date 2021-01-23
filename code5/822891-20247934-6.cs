    public class Index_Listar_Produtos
    {
        public List<Listar_Produto> Index_List_Produto { get; set; }
        [Display(Name = "Data de Cadastro Inicial")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> CadastroInicialData { get; set; }
        [Display(Name = "Data de Cadastro Final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [GreaterThanOrEqualTo("CadastroInicialData", ErrorMessage = "\"Data Inicial\", deve ser maior que \"Data Final\"")]
        public Nullable<DateTime> CadastroFinalData { get; set; }
        public string GetStringTypeCadastroInicialData
        {
            get { return CadastroInicialData != null ? CadastroInicialData.Value.ToShortDateString() : DateTime.MinValue.ToShortDateString()(Or empty string ); }
        }
        public string GetStringTypeCadastroFinalData
        {
            get { return CadastroInicialData != null ? CadastroFinalData.Value.ToShortDateString() : DateTime.Now.ToShortDateString(); }
        }
    }
