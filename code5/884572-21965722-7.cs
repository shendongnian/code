    public class Entidade
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Nome { get; set; }
    
            [ForeignKey("Pais")]
            public int PaisId { get; set; }
            public virtual Pais Pais { get; set; }
        }
