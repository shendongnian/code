    public ActionResult _ProdutoMasterGrid(string param)
    {
        return View("Index",
        repository.Compare(param).ToList());
    }
