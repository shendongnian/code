    [Authorize]
    [ControleDeAcesso(TipoAcao.Normal)]
    public ActionResult Detalhar(int id)        
    {
        Cliente cliente = null;
        using (var db = new ERPContext())
        {
            cliente = db.Cliente.Find(id);
            var retorno = FlexGestor.Helpers.EntidadeBaseExt.ValidarRegistro(cliente, TipoAcao.Visualizar);
            if (retorno != "")
            {
                TempData["MsgRetornoError"] = retorno;
                return RedirectToAction("Index", "Home");
            }
        }
        
        if(cliente != null && cliente.pessoa != null)
        {
            return View(cliente);
        }
        else
        {
            // do something else here as the view does not have required stuff
        }
    }
