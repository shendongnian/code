          if (ModelState.IsValid)
          {
				// Your logic here ...
				// ...
				
				// return true if successfull
               return Json(new { success = true});    
          }
          return Json(new
          {
              success = false,
              errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray()
          });
