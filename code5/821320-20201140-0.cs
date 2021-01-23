    [Table("Menus")]
    public class Menus
    {
        [Key]
        public int ID { get; set; }
    
        public string MenuName { get; set; }
    
        [ForeignKey("ParentMenu")]
        public int ParentID { get; set; }
        public virtual Menu ParentMenu { get; set; }
        public virtual List<Menu> ChildMenus { get; set; }
    }
