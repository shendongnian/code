    public class ColumnWidthMetaData {
        [DisplayName("Column Name")]
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        public string ColName { get; set; }
        [DisplayName("Primary Key")]
        public int pKey { get; set; }
        [DisplayName("User Name")]
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        public string UserName { get; set; }
        [DisplayName("Column Width")]
        [Required]
        public int Width { get; set; }
    }    
    
