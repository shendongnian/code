    @if (ViewBag.MainMenusList != null)
                    {
                        foreach (DataAccess.GeneratedMenus mainMenu in ViewBag.MainMenusList)
                        {
                            <li class="dropdown">
                                <a class="dropdown-toggle" data-toggle="dropdown">
                                    @mainMenu.MenuName
                                </a>
                                <ul class="dropdown-menu">
                                 @foreach (DataAccess.GeneratedMenus subMenu in ViewBag.SubMenuList)
                                    {
                                        if (subMenu.ParentID == mainMenu.MenuID)
                                        {
                                          <li>
                                          @Html.ActionLink(
                                          @subMenu.MenuName, 
                                          @subMenu.ActionName, 
                                          @subMenu.ControllerName)
                                          </li>
                                        }
                                    }
                                </ul>
                            </li>
                        }
                    }
