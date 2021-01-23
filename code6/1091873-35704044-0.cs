        [Key]
        [Display(Name = "Idee ID")]
        public int intIdeaID { get; set; }
        [Required(ErrorMessage = "Dieses Feld muss ausgefüllt werden")]
        [Display(Name = "Idee")]
        [Remote("ideaExists", "TabIdea", HttpMethod = "POST", ErrorMessage = "Es wurde bereits eine Idee mit dieser Bezeichnung erstellt", AdditionalFields = "intIdeaID")]
        public string strIdea { get; set; }
