    namespace TestSite.Models
    {
        public class MY_ACTIONS
        {
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public MY_ACTIONS()
            {
                this.o_actions = new HashSet<MY_ACTIONS>();
            }
            [Key]
            public int action_id { get; set; }
            [StringLength(100)]
            public string action_name { get; set; }
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<MY_ACTIONS> o_actions { get; set; }
        }
    }
