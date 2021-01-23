    public partial class Movie
    {
         public long MovieId { get; set; }
         [Required]
         [StringLength(100)]
         public string name { get; set; }
         [Required]
         public string UserId { get; set; }
         [ForeignKey("UserId")]
         public virtual ApplicationUser Owner {set;get;}
    }
