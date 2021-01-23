    ValidationContext vc = new ValidationContext(sta);
    ICollection<ValidationResult> results = new List<ValidationResult>(); // results of the validation
    bool isValid = Validator.TryValidateObject(mvm, vc, results, true); // Validates the object and its properties 
     int newId = 0;
     if (isValid)
     {
         // Save MVM
         newId = repository.SaveMVM(mvm); // function should save record and return ID
         return View("Edit", new { mvm.Id = newId });
      }
      else
          RedirectToAction("Edit", mvm);
