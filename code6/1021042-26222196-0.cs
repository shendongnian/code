            if (Request.IsAjaxRequest())
            {
                if ("Print Call List" == command)
                {
                    TempData.Add("SelectedArea", searchModel.SelectedArea);
                    searchModel.ShowCallList = true;
                }
                searchModel.SearchResults = ExecuteSearch(searchModel);
                return PartialView("_SearchResults", searchModel);
            }
