        Public ActionResult Edit (int? id)
        {
               if (!id.HasValue)
               {
                 RedirectToAction("Add");
               }
               // Edit code goes here   
        
        }
`
