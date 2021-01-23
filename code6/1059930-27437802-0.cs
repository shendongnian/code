    public class Submenu
    {
        public string SubName { get; set; }
    }
    public class ParentMenu
    {
        public string ParentName { get; set; }
        public List<Submenu> SubMenus { get; set; }
    }
    public class Menus
    {
        [XmlElement("ParentMenu")]
        public List<ParentMenu> ParentMenus { get; set; }
    }
