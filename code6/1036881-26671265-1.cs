      public JsonResult GetStates(string country)
        {
            var states = new List<string>();
            switch (country)
            {
                case "USA":
                    states.Add("California");
                    states.Add("Florida");
                    states.Add("Ohio");
                    break;
                case "UK":
                    states.Add("London");
                    states.Add("Essex");
                    break;
                case "India":
                    states.Add("Goa");
                    states.Add("Punjab");
                    break;
            }
    
            //Add JsonRequest behavior to allow retrieving states over http get
            return Json(states, JsonRequestBehavior.AllowGet);
        }
