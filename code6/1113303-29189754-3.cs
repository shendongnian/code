    public class Measurement
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        ....
        // Won't need these
        // public virtual ICollection<Picture> Pictures { get; set; }
    
    
        public virtual Picture LeftPicture { get; set; }
        public virtual Picture TopPicture { get; set; }
        public virtual Picture RightPicture { get; set; }
        public virtual Picture BottomPicture { get; set; }
    }
