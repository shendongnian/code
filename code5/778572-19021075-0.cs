    public class AT_APSRANCD
    {
        [Column(Order = 0), Key, ForeignKey("AC_Analysis_category")]
        public int AC_Analysis_category{ get; set; }
    
        [Column(Order = 1), Key, ForeignKey("AC_ANALYSI_CODE")]
        public int AC_ANALYSI_CODE{ get; set; }
    }
