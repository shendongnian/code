                if (SearchParameter != null)
                {
                    TempData["HoldSearch"] = SearchParameter;
                    TempData.Keep();
                }
                else
                {
                    SearchParameter  = (CastBacktoType)TempData["HoldSearch"];
                    TempData.Keep();
                }
