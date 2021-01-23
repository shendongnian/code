    public async Task<ActionResult> Home() { 
        var taskA = A(model);
        var taskB = B(model);
        await Task.WhenAll(taskA, taskB);
        return View("Home", model);
    }
