     public class Car
     {
        [Key]
        [Required]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
 
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
 
        [Required]
        public DateTime Date{ get; set; }
 
        public virtual int CategoryID { get ; set;}
 	
        public virtual Category Category { get; set; }
 
     }
 
