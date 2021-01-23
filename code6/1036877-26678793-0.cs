    Hi Jinava,
    
    I would suggest bind Model to the View,
    
    Like,
    
      public ActionResult CategoryRepeater()
            {
                var multiViewModel = new MultiViewModelModel
                {
                    ModelForParialView1= new XYZ(),
                    ModelForParialView2= new PQR()
                };
    
                return View(model);
    
               
            }
    
    
    
    For the View 
    @model MultiViewModelModel
    
    And then PAss the views with the MultiViewModelModel.ModelForParialView1 and MultiViewModelModel.ModelForParialView2
    
    You can perform all the model operations on the view.
    
    And at the controller level perform all the database operations and release the database connection there itself no need to get that on the view.
    
    Hope this explanation helps you.
