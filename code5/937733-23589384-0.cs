       public partial class Business
       {
         [Key] //And this one should be the key 
         public int BusinessKeyId { get; set; }
         [Required]
         public string BusinessName { get; set; }
         [Required]
         public string BusinessType { get; set; }
         [Required]
         public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
       }
