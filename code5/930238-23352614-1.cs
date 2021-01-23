        var result = controller.Index() as Task<ViewResult>;
       // Get the actual result from the task
        var viewresult = result.Result;
        // Get the model from the viewresult and cast it to the correct type 
        // (notice in the first line I changed ActionResult to ViewResult to make sure we can access the model.
        var model = (List<Client>)(viewresult.Model);
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, model.Count);
