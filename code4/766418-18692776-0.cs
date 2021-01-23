    @foreach (var item in pro.Models.SiteContentModel.GetMenuContent())
    {
          switch (item.tpage.PAGE_NAME)
          {
               case "details":
                    if (item.tuserAccess.ACC_STATUS == true)
                    {
                         <li>@Html.ActionLink("details", "Index", "Business")</li>
                    }
                    break;                
           }
    }
