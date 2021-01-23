      public class UserTecnologies
        {
            [Key]
            public int UserTecId { get; set; }
            [ForeignKey("UserProfile")]
            public virtual int UserProfileId { get; set; }
            [ForeignKey("Tecnology")]
            public virtual int TecnologyId { get; set; }
    
            public virtual Tecnologies Tecnology { get; set; }
            public virtual UserProfile UserProfile { get; set; }
                
            [Required]
            public int Rating { get; set; }
        }
