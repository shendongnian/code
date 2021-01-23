      public partial class TAUX
     {
         [Key] //Add this if you want the Find method working
         public int TAUX_ID { get; set; }  
        [Required(ErrorMessage = "Taux est obligatoire")]
        public decimal POURC_TAUX { get; set; }
        public System.DateTime DATE_EFFET { get; set; }
        public short CAT_ID { get; set; } // foreign key
        public virtual CATEGORIE CATEGORIE { get; set; }
        public int C_GARANT { get; set; } // foreign key 
        public virtual GARANTIE GARANTIE { get; set; }
       }
