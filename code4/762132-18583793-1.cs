    public class OpCadastros1Model 
    {
        [Key, Column("id"), ForeignKey("Operador")]
        public int OperadorId { get; set; }
        [Required]
        public Operador Operador { get; set; }
    }
