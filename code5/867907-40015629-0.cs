      @if (ViewContext.RouteData.Values["controller"].ToString().ToLower() != "home")
      {
           <ol class="breadcrumb">
                 <li>
                  @Html.ActionLink("Home", "Index", "Home")
                 </li>
                 <li> @Html.ActionLink(ViewContext.RouteData.Values["controller"].ToString(), "Index")
                 </li>                                
                 <li class="active"> @Html.ActionLink(ViewContext.RouteData.Values["action"].ToString(), ViewContext.RouteData.Values["action"].ToString())
                 </li>                                                       
            </ol>
       }
