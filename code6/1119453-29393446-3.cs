    // FormVariable "accountID=1&userID=23"
    [HttpPost]
    public Task<JSONResult> Get(int accountID, int userID)
    {  
         //To get the Current Request, just start typing Request
        Request.Browser();
        MyModel myModel = await Get.MyModel(id);
        return JSON(myModel);
    }
