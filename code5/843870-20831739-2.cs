    public List<SelectListItem> GetTypes()
    {
      var list=new List<SelectListItem>();
      list.Add(new SelectListItem { Value="Books", Text="Books"});
      list.Add(new SelectListItem { Value="Movies", Text="Movies"});
      list.Add(new SelectListItem { Value="Games", Text="Games"});
      return list;
    }
