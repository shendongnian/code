    @if (HttpContext.Current.Request.Cookies[MyCookies.SelectedRegion] != null)
     {
        Model.SelectedRionName = HttpContext.Current.Request.Cookies[MyCookies.SelectedRegion].Value;
        @Html.DropDownListFor(m => m.SelectedRionName, Model.RegionList)
     }
     else
     {
       @Html.DropDownListFor(m => m.SelectedRionName, Model.RegionList, "Select")
     }
