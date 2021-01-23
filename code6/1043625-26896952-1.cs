        [HttpGet]
        public ActionResult CheckIn()
        {
            var model = new CheckInViewModel
            {
                CheckIn_Location_List = repository.GetCageLocations().Select(
                    location => new SelectListItem
                    {
                        Value = location.Id.ToString(),
                        Text = location.LocationName
                    })
            };
            return View(model);
        }
