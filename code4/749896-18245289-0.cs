    [HttpGet]
    public ActionResult BookStore(int storeId)
    {
        //model contains a list property like the following:
        //public List<Books> BooksList { get; set; }
        //pass the model to the view
        var model = new BookStoreModel();
   
        return View(model);
    }
