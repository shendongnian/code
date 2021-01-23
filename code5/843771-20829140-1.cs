       public PartialViewResult Partial1()
            {
                ViewData.Model = new List<Type1.Test>();
                return PartialView();
            }
