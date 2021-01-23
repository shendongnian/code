    namespace TestSite.Models
    {    
        [Table("MAIN_TABLE")]
        public partial class MAIN_TABLE
        {
            [Key]
            public int MAIN_TABLE_ID { get; set; }
            public int LASTACTION { get; set; } // this would carry a number matching action_id
            [ForeignKey("LASTACTION")]
            public virtual MY_ACTIONS MY_ACTIONS { get; set; }
        }
    }
