    [HttpPost]
        public ActionResult li(int activepage = 0,Buscador bu = null)
        {
         ..my code to format values...
         ..send values below that interest me routing.. 
         return RedirectToRoute("list", new System.Web.Routing.RouteValueDictionary { { "bti", bu.bti }, { "bop", bu.bop }, { "blo", bu.blo }, { "bzo", bu.bzo }, { "bpr", bu.bpr }, { "bha", bu.bha }, { "bor", bu.bor } });
        }
