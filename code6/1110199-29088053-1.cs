        public class menuVM
        {
            public static List<menuItemVM> AllMenuItems { get; set; }
    
            public IEnumerable<menuItemVM> rootMenuitems
            {
                get { return menuVM.AllMenuItems.Where(c => c.ParentId == null); }
            }
        }
    
        public class menuItemVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ParentId { get;set; }
    
            public IEnumerable<menuItemVM> Childern {
                get
                {
                    return menuVM.Childern.Where(c => c.ParentId == this.Id);
                }
            }
        }
