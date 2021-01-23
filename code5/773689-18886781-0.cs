  
       [HttpPost]
        public ActionResult TableEdit(string modelData)
        {
            List<ViewModel> listOfModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model>>(modelData);
            return View();
        }
