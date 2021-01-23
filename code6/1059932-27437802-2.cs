    var menus = (from Parent in xdoc.Root.Descendants("ParentMenu")
                 select new ParentMenu
                 {
                     ParentName = Parent.Descendants("ParentName").First().Value,
                     SubMenus = (from sub in Parent.Descendants("SubMenus")
                                                   .Descendants("Submenu")
                                 select new Submenu
                                 {
                                     SubName = sub.Descendants("SubName")
                                                  .First().Value,
                                 }).ToList()
                 }).ToList();
