        public ActionResult GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            //... code here
         
            return PartialView("_IndexPartial", employees); 
        }
        
