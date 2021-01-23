            public class User
            {
                [Key, ScaffoldColumn(false), Display(Name = "ID User")]
                public int idUser { set; get; }
            
                [Required, StringLength(16), Display(Name = "Login")]
                public string login { set; get; }
            
                [Required, StringLength(16), Display(Name = "Password")]
                public string password { set; get; }
            
                public virtual Reclamation Reclamation {get; set;}
        
                /*if you have one to many relationship, use Collection<T> 
       and initialize it in the constructor Reclamations = new Collection<Reclamation>();*/
                public virtual Collection<Reclamation> Reclamations {get; set;}
            }
