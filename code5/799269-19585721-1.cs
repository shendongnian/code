     public class MenuDto
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<MenuDto> SubMenus  { get; set; }
    }
    _model.Menus.Where(m => m.Active)
                .Select(p => new MenuDto
                {
                    MenuId = p.idField,
                    Name = p.NameField,
                    Url = p.UrlField,
                    SubMenus = p.SubMenus.Where(sb => sb.Active)
                        .Select(y => new MenuDto
                        {
                            MenuId = y.idField,
                            Name = y.NameField,
                            Url = y.UrlField,
                            SubMenuItem = y.SubMenuItems.Where(sbi => sbi.Active)
                              .Select(z => new MenuDto
                        {
                            MenuId = z.idField,
                            Name = z.NameField,
                            Url = z.UrlField
                        })
                        })
                }).ToList();
