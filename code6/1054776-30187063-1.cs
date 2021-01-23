        [HttpGet]
        public object Get([FromUri]Employee employee)
        {
            if (employee != null && ModelState.IsValid)
            {
                // Do something with the product (not shown). 
                return employee;
            }
            
            return employee;
        }
