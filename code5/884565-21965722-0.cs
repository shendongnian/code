    public Pais()
            {
                Entidades = new HashSet<Entidade>();
            }
    
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Nome { get; set; }
    
            public virtual ICollection<Entidade> Entidades { get; set; }
