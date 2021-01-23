    @{ var menusList = ViewBag.Menu as IEnumerable<LaboratorySpecimenTrackingSystem.WebApp.Models.MenuModel>; }
     @if (menusList != null)
    {
       <ul id="menu" class="wrap cf">
        @foreach (var parentMenu in menusList.Where(p => p.ParentMenuID == 0))
        {
            <li>
                @if (!string.IsNullOrEmpty(@parentMenu.ActionName))
                {
                     @Html.ActionLink(@parentMenu.MenuName, @parentMenu.ActionName, @parentMenu.ControllerName)
                }
               else
               {
                  <span>@parentMenu.MenuName</span> 
                    if (menusList.Count(p => p.ParentMenuID == parentMenu.MenuID) > 0)
                    {
                        <ul>
                            @foreach (var childMenu in menusList.Where(p => p.ParentMenuID == parentMenu.MenuID))
                            { 
                                 <li>@Html.ActionLink(@childMenu.MenuName, @childMenu.ActionName, @childMenu.ControllerName)</li>
                      
                                if (menusList.Count(p => p.ParentMenuID == childMenu.MenuID) > 0)
                                {
                                    foreach (var subChild in menusList.Where(p => p.ParentMenuID == childMenu.MenuID))
                                    {
                                @Html.ActionLink(@subChild.MenuName, @subChild.ActionName, @subChild.ControllerName)
                                    }
                                }
                            }
                        </ul>
                    }        
               }
               
            </li>
        }
     </ul>
    }
