     @Html.DropDownListFor(x => x.LeagueId, Model.LeagueSL, "--Select League--", new { id = "ddlLeague"})
    public ActionResult Index()
        {
            BaseballViewModel model = new BaseballViewModel();
            using (BaseballEntities context = new BaseballEntities())
            {
                var leagueList = context.League.ToList();
                foreach (var item in leagueList)
                {
                    model.LeagueSL.Add(new SelectListItem() { Text = item.LeagueName, Value = item.LeagueId.ToString() });
                }
            }
            return View(model);
        }
