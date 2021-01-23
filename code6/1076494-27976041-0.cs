    @if (Model.Filters.IsReturnsOptionsAvailable)
    {
      Html.RenderPartial("_CheckBoxFilterPartial", Model.clmReturnOptions, new ViewDataDictionary
      {
        TemplateInfo = new System.Web.Mvc.TemplateInfo { HtmlFieldPrefix = "clmReturnOptions" }
      })
    }
