    public class MenuCategoryModel : List<MenuItemModel>
    {
        public MenuCategoryModel() { }
        public int Menucategoryid { get; set; }
        public int Menuid { get; set; }
        public string Categoryname { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string Createddate { get; set; }
        public object Modifieddate { get; set; }
    }
    public class MenuItemModel : MenuItem { }
