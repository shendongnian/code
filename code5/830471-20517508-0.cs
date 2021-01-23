    public class Menu
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
    
        public virtual ICollection<SubMenu> SubMenus { get; set; }
    
        public Menu()
        {
            SubMenus = new List<SubMenu>();
        }
    }
