     public class GiroEntity
    {
        [Key(), Editable(false)]
        public int IdGiro { get; set; }
        [Required(ErrorMessage = "La descrizione del giro e' obbligatoria"), Editable(false), StringLength(50)]
        public string DescrizioneGiro { get; set; }
        [Include]
        [Association("AssocTappe", "IdGiro", "ParentId", IsForeignKey = false)]
        //[Required(ErrorMessage = "Per il giro devono essere definite delle tappe")]
        public List<TappaEntity> Tappe { get; set; }
    }
     public class TappaEntity
    {
        [Key(), Editable(false)]
        public int IdTappa { get; set; }
        [Required(ErrorMessage = "La descrizione della tappa e' obbligatoria"), Editable(false), StringLength(50)]
        public string DescrizioneTappa { get; set; }
        public int? ParentId { get; set; }
        [Include]
        [Association("AssocTappe", "ParentId", "IdGiro", IsForeignKey = true)]
        public GiroEntity Giro { get; set; }
        
    }
