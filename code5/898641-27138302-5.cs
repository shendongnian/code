    [HttpPost]
        public ActionResult listadoinmueblesbuscador(int activepage = 0,Buscador busqueda = null)
        {
         ..my code to format values...
         ..send values below that interest me routing.. 
         return RedirectToRoute("listadoinmueblesbuscador", new System.Web.Routing.RouteValueDictionary { { "btipo", busqueda.btipo }, { "boperacion", busqueda.boperacion }, { "blocalidad", busqueda.blocalidad }, { "bzona", busqueda.bzona }, { "bprice", busqueda.bprice }, { "bhabitaciones", busqueda.bhabitaciones }, { "borderby", busqueda.borderBy } });
        }
