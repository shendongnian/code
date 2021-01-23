    [HttpGet]
    public ActionResult Currency()
    {
        var model = unitOfWork.CurrencyRepository.GetAll().ToList();
        return View(model);
    }
