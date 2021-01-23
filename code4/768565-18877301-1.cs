     [HttpPost]
        public ActionResult PBHEP(string PC,string FC)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Conditions> PC_rows = ser.Deserialize<List<Conditions>>(PC);
            List<Conditions> FC_rows = ser.Deserialize<List<Conditions>>(FC);
        }
