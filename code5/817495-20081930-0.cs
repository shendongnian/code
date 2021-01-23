    public class Customer : //etc
    {
       
       //your stuff
       [Required]
       public int EyeColorTypeID {get; set;}
       public virtual EyeColorType EyeColorType { get; set; }
    }
