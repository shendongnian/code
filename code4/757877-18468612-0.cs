        public ActionResult Index()
        {
            List<Women> womens = new List<Women>
                {
                    new Women
                        {
                             Id=1,
                             FirstName = "Women1",
                             LastName = "Lastname1"
                        },
                    new Women
                        {
                             Id=2,
                             FirstName = "Women2",
                             LastName = "Lastname2"
                        }
                };
            WomenList womenList=new WomenList();
            womenList.Womens = womens;
            return View(womenList);
        }
