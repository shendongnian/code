    public ActionResult Temas(int nid)
        {
        Session["user_name"] = Session["user_name"];
        Session["IDG"] = Session["IDG"];
        Session["ID"] = Session["ID"];
        Tema tem = new Tema();
        List<Tema> temas = new List<Tema>(); 
        temas = tem.ObtenerTemasPorCategoriaID(nid);
        Categoria cat = new Categoria();
        ViewBag.NombreCat = cat.obtenerNombreCategoriaById(nid);
        return View();
    }
