    public class t
        {           
            public string val { get; set; }
        }
        public class j
        {
            public string val { get; set; }
        }
    
    
    public ActionResult Index()
            {
                var litT = new List<t>();
                var litJ = new List<j>();
                t objT = new t();
                j objJ = new j();
                objT.val = objJ.val = "A";
                litT.Add(objT);
                litJ.Add(objJ);
                objT.val = objJ.val = "B";
                litT.Add(objT);
                litJ.Add(objJ);
                objT.val ="C";
                litT.Add(objT);
    
                var result = litT.Where(p => p.val != litJ.Select(k => k.val).ToString()).ToList().Distinct();
    
                return View();
            }
