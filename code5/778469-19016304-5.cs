     var viewModel = new MedicalProductViewModel
     {
         BrandID = 12,
         BrandName = "Some Brand",
         ID = 6,
         Name = "Some Name",
         Price = 12.27,
         BrandSelectListItem = new List<SelectListItem>()
         {
               new SelectListItem() {Text = "Item 1", Value = "1"},
               new SelectListItem() {Text = "Item 2", Value = "2"}
         }
     };
     return View(viewModel);
