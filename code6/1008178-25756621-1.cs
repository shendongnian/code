            [Required]
        [RegularExpression(@"[Tt,Ss]-\d\d", ErrorMessage="Debe colocar un Código de Operador válido.")]
        [Remote("ExisteCodOp","Pool")]
        [DisplayName("Código Operador")]
        public string Codigo_Operador { get; set; }
