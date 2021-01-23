    [HttpPost]
        public ActionResult listadoinmueblesbuscador(int activepage = 0,Buscador busqueda = null)
        {
         return RedirectToRoute("listadoinmueblesbuscador", new System.Web.Routing.RouteValueDictionary { { "btipo", busqueda.btipo }, { "boperacion", busqueda.boperacion }, { "blocalidad", busqueda.blocalidad }, { "bzona", busqueda.bzona }, { "bprice", busqueda.bprice }, { "bhabitaciones", busqueda.bhabitaciones }, { "borderby", busqueda.borderBy } });
        }
