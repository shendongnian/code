    @foreach (var item in ViewBag.menu)
       {
          <li class="divider"></li>
            if (item.SubMenu != null){
                 @foreach (var subMenu in item)
                 {
                   ...
                 }
            }
            else
            {
                <li>
                    <a href="/@item.ControllerName/@item.ActionName/@item.OrganizationId" class="">@item.LinkText</a>
            </li>
            }
      }
