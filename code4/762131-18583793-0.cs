    public class Operador
    {
        [Key, Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperadorId { get; set; }
        public virtual OpCadastros1Model OpCadastros1 { get; set; }
    }
