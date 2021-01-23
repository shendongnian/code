    @foreach (var item in pro.Models.SiteContentModel.GetMenuContent())
    {
          switch (((DAL.t_PAGES)(item)).tpage.PAGE_NAME)
          {
               case "details":
                    if (((DAL.USER_ACCESS)(item)).tuserAccess.ACC_STATUS == true)
                    {
                         <li>@Html.ActionLink("details", "Index", "Business")</li>
                    }
                    break;                
           }
    }
