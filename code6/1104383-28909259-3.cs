    @model MasterVM
    @using Html.BeginForm())
    {
      if(Model.Model1 != null)
      {
        @Html.Partial("_Model1", Model.Model1, new ViewDataDictionary { TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "Model1" }})
      }
      if(Model.Model2 != null)
      {
        @Html.Partial("_Model2", Model.Model2, new ViewDataDictionary { TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "Model2" }})
      }
      ....
      <input type="submit" />
    }
