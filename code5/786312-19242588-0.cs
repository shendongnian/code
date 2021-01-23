    public async Task<JsonResult> AControllerMethodInAspMVC()
    {
        var arrayOfItem =  …; 
        var tasks = arrayOfItem.Select(
            item => api.GetResultFromAnotherService(item.id));
        return await Task.WhenAll(tasks);
    }
