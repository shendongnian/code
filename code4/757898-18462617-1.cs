    @Url.Action("Index","Search",new SkillKindleWeb.ViewModels.Search.SearchRawInput()
    {
      CategoryIds = string.Join(",", Model.Request.CategoryIds),
      SubCategoryIds = string.Join(",", Model.Request.SubCategoryIds),
      StartDate = Model.Request.StartDate.ToShortDateString(),
      EndDate = Model.Request.EndDate.ToShortDateString(),
      StartPrice = Model.Request.StartPrice,
      LocationGroupIds = Model.Request.LocationGroupIds,
      LocationIds = Model.Request.LocationIds,
      EndPrice = Model.Request.EndPrice,
      City = Model.Request.City,
      PageNo = 1,
      SearchQuery = Model.Request.SearchQuery,
      Segment1 = Model.Request.Segment1,
      Segment2 = Model.Request.Segment2,
      TargetAge = Model.Request.TargetAge
    })
