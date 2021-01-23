        public ActionResult Edit(int id = 0)
        {
            HousingTypeDropDownViewModel housingType = new HousingTypeDropDownViewModel
            {
                Items = _repo.EditHousingType(id)
            };
            HouseholdEditViewModel h = GetUpdate(id);
            //GetUpdate is Automapper code unrelated to the DropDown 
            h.housingTypeID = housingType;
                
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }
