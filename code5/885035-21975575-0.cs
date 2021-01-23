    public class EntidadeEditViewModel
    {
        [Required]
        public int? Id { get; set; }
    
        [Required]
        [Display(Name = "País")]
        public string PaisNome { get; set; }
    
        [Required]
        [Display(Name = "Ordem")]
        public int? PaisOrdem { get; set; }
    }
