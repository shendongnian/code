     _model.Menus.Where(m => m.Active)
                .Select(p => new
                {
                    Menu = x,
                    SubMenu = x.SubMenus.Where(sb => sb.Active)
                        .Select(y => new
                        {
                            SubMenu = y,
                            SubMenuItem = y.SubMenuItems.Where(sbi => sbi.Active)
                        })
                }).ToList();
