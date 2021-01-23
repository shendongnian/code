        public ActionResult GetOfertaSOAP()
        { 
            SoapService.Service1Client client = new SoapService.Service1Client()
            List<SoapService.Oferta> lst = client.GetOferta().ToList();  
            return View("GetOfertaSOAP", lst);
        }
 
