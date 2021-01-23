        [HttpPost]
        public ActionResult Create([Bind(Exclude = "RequiredProperty")]MyViewModel myViewModel)
        {
           if(ModelState.IsValid)
           {
             //
           }
        
        }
