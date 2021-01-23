         public class Device
        {
           public int Id {get; set;}
           public ICollection<Setting> Settings {get; set;}
        }
        
        public class Setting
        {
           [Required]
           public int Id {get; set;} 
           [Range(1,10)]
           public string Value {get; set;}
           [Required]
           public bool IsRequired {get; set;}
           public int MinLength {get; set;}
           public int MaxLength {get; set;}
        }
