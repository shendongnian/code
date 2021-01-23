    public PartialViewResult ChangeLanguage(int id) {
      HomeViewModel model = new HomeViewModel();
      model.SelectedLanguage = model.AvailableLanguages.Where(o => o.ID.Equals(id)).First();
      model.SelectedTitle = model.Title.Where(o => o.Language.Equals(model.SelectedLanguage)).First();
      return PartialView(model); // the partial just contains the elements you want to update
    }
