    [HttpPost]
        public ActionResult CheckIn(CheckInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // This is necessary because we are sending the model back to the view.
                // You could cache this info and do not take it from the DB again.
                model.CheckIn_Location_List = repository.GetCageLocations().Select(
                    location => new SelectListItem
                    {
                        Value = location.Id.ToString(),
                        Text = location.LocationName
                    });
                return PartialView("CheckIn", model);
            }
            var New_Transaction = new Transaction
            {
                Id = model.CheckIn_Id,
                Quantity = model.CheckIn_Quantity,
                LocationId = Convert.ToInt32(model.CheckIn_Location_Selected),
                TransactionDate = DateTime.Now,
                TransactionComments = model.CheckIn_Comment.Replace("\r\n", " ")
            };
            unitOfWork.TransactionRepository.Insert(New_Transaction);
            unitOfWork.Save();
            return PartialView("CheckIn", model);
        }
