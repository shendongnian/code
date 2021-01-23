       [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Index(SINCO_LOCALIDADE_CONCESSAO model)
             {
                          return View("Index", db.SINCO_LOCALIDADE_CONCESSAO.Include(s => s.LOCALIDADES_VIEW).Include(s => s.MUNICIPIOS_VIEW));
     }
