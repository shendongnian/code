    public ActionResult Search()
    {
      var vm=new PersonSearchVM { Genders=GetGenders()};
      return View(vm);
    }
    [HttpPost]
    public ActionResult Search(PersonSearchVM model)
    {
      string selectedVal=model.SelectedGender;
      if(!String.IsNullOrEmpty(selectedVal)
      {
        model.Results=GetSearchResultsFromSomeWhere(selectedVal);
      }
      model.Genders=GetGenders(); //reload dropdown items
      model.SelectedGender=selected;
      return View(model);
    }
    private List<SelectListItem> GetGenders()
    {
      return new List<SelectListItem> { 
         new SelectListItem { Value="Male",Text="Male"},
         new SelectListItem { Value="Female",Text="Female"},
      };
    }
