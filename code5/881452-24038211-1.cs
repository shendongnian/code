        [DisplayName("Sex")]
        [Required(AllowEmptyStrings=false)]
        public Sex? Sex { get; set; }
        Sex = null;
        Sexes = Repository.GetAutoSelectList<Sex>("");
